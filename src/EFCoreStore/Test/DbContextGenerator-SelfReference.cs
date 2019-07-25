using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    public partial class DbContextGenerator
    {
        public  void CategorySelfReferenceTester()
        {
             GetCategoriesByTask();

            //await  ClearCategories();
            //await DeleteCategories();
            // await AddCategories();
            //UpdateCategories();
        }

        public  void GetCategoriesByTask()
        {
            #region 读取

            var task1 = Task.Factory.StartNew(async () =>
            {
                var categories = await GetCategories();
                Console.WriteLine($"ManagedThreadId:\t{Thread.CurrentThread.ManagedThreadId}");
              
            });
            //await task1;

            //var task1 = Task.Run(() =>
            //{
            //    var categories =  GetCategories();

            //    Console.WriteLine($"ManagedThreadId:\t{Thread.CurrentThread.ManagedThreadId}");
            //var allCategories = (from c in context.Categories
            //             select c).ToList();

            //foreach (var cat in allCategories)
            //{
            //    Console.WriteLine($"Name:{cat.Name}\tPath:{cat.Path}");
            //}
            //});

           // await Task.WhenAll(task1);
            #endregion
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (var context = new EFCoreStoreContext())
            {
                var roots = await (from c in context.Categories.AsNoTracking()
                                   where c.ParentId == null
                                   select c).ToListAsync();

                foreach (var c in roots)
                {
                    await RecursiveCategory(c, categories, context);
                }
            }
            return categories;
        }

        private async Task RecursiveCategory(Category currentCategory, List<Category> categories, EFCoreStoreContext context)
        {
            categories.Add(currentCategory);
            // Console.WriteLine($"Name:{currentCategory.Name}\tPath:{currentCategory.Path}");

            var subCategories = await (from c in context.Categories.AsNoTracking()
                                       where c.ParentId == currentCategory.CategoryId
                                       select c).ToListAsync();
            foreach (var child in subCategories)
            {
                await RecursiveCategory(child, categories, context);
            }
            Console.WriteLine($"Name:{currentCategory.Name}\tPath:{currentCategory.Path}");
        }

        public async Task AddCategories()
        {
            var context = new EFCoreStoreContext();
            #region 保存
            try
            {
                var category1 = new Category { Name = "category1", Path = "1", Parent = null };
                context.Categories.Add(category1);
                await context.SaveChangesAsync();

                var category2 = new Category { Name = "category2", Path = "1:2", Parent = category1 };
                context.Categories.Add(category2);
                await context.SaveChangesAsync();

                var category3 = new Category { Name = "category3", Path = "1:3", Parent = category1 };
                context.Categories.Add(category3);
                await context.SaveChangesAsync();

                var category4 = new Category { Name = "category4", Path = "1:3:4", Parent = category3 };
                context.Categories.Add(category4);
                await context.SaveChangesAsync();

                var category5 = new Category { Name = "category5", Path = "1:3:5", Parent = category3 };
                context.Categories.Add(category5);
                await context.SaveChangesAsync();

                var category6 = new Category { Name = "category6", Path = "6", Parent = null };
                context.Categories.Add(category6);
                await context.SaveChangesAsync();

                var category7 = new Category { Name = "category7", Path = "6:7", Parent = category6 };
                context.Categories.Add(category7);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                context.Dispose();
            }
            #endregion
        }

        public void UpdateCategories()
        {
            #region  更新
            //Blog updateBlog = null;
            //BlogImage updateBlogImage = null;
            //try
            //{
            //    updateBlogImage = await (from bi in context.BlogImages
            //                      where bi.BlogImageId == 3
            //                      select bi).FirstOrDefaultAsync();
            //    if (updateBlogImage != null)
            //    {
            //        updateBlogImage.Caption = "UpdateCaption1";
            //        updateBlogImage.Image = new byte[110];
            //        context.Entry<BlogImage>(updateBlogImage).State = EntityState.Modified;
            //        await context.SaveChangesAsync();
            //    }

            //    updateBlog = await (from b in context.Blogs.Include(b => b.BlogImage)
            //                        where b.BlogId == 7
            //                        select b).FirstOrDefaultAsync();
            //    if (updateBlog != null)
            //    {
            //        updateBlog.Title = "UpdateBlog2";
            //        updateBlog.BlogImage.Caption = "UpdateCaption2";
            //        updateBlog.BlogImage.Image = new byte[10];
            //        context.Entry<Blog>(updateBlog).State = EntityState.Modified;
            //        await context.SaveChangesAsync();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            #endregion
        }

        public async Task ClearCategories()
        {
            #region 全部删除
            try
            {
                using (var context = new EFCoreStoreContext())
                {
                    context.Database.OpenConnection();
                    await context.Database.ExecuteSqlCommandAsync("DELETE FROM Category");
                    context.Database.CloseConnection();
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }

        public async Task DeleteCategories()
        {
            #region 删除
            try
            {
                using (var context = new EFCoreStoreContext())
                {
                    //var roots =await (from c in context.Categories.AsTracking()
                    //             where c.ParentId == null
                    //             select c).ToListAsync();
                    var roots = await context.Categories.AsNoTracking().Where(c => c.ParentId == null).ToListAsync();
                    foreach (var c in roots)
                    {
                        await RecursiveDeleteCategory(c, context);
                    }
                };

                //1.单独删除BlogImage
                //var sroredBlogImage1 = await context.BlogImages.FirstOrDefaultAsync(bi => bi.BlogImageId == 10);
                //var blogId1 = sroredBlogImage1.BlogId;
                //if (sroredBlogImage1 != null)
                //{
                //    context.BlogImages.Remove(sroredBlogImage1);
                //    await context.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }

        private async Task RecursiveDeleteCategory(Category currentCategory, EFCoreStoreContext context)
        {
            var subCategories = await (from c in context.Categories.AsNoTracking()
                                       where c.ParentId == currentCategory.CategoryId
                                       select c).ToListAsync();
            foreach (var child in subCategories)
            {
               await  RecursiveDeleteCategory(child, context);
            }
            try
            {
                using (EFCoreStoreContext dbContex = new EFCoreStoreContext())
                {
                    var sroredCategory = await dbContex.Categories.SingleOrDefaultAsync(c => c.CategoryId == currentCategory.CategoryId);
                    if (sroredCategory != null)
                    {
                        Console.WriteLine($"正在删:\t\tName:{currentCategory.Name}\tPath:{currentCategory.Path}");
                        dbContex.Categories.Remove(sroredCategory);
                        await dbContex.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
