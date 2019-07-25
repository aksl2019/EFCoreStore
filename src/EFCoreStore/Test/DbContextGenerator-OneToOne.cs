using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    public partial class DbContextGenerator
    {
        public async void BlogOneToZeroOrOneTester()
        {
            var context = new EFCoreStoreContext();

            #region 保存
            try
            {
                #region 1.先保存BlogImage,再保存Blog
                //var blogImage2 = new BlogImage { Caption = "Image2", Image = new byte[20] };
                //context.BlogImages.Add(blogImage2);
                //await context.SaveChangesAsync();

                //var blog2 = new Blog
                //{
                //    Title = "Blog2",
                //    Url = "http://Blog2",
                //    BlogImage = blogImage2
                //};
                //context.Blogs.Add(blog2);
                //await context.SaveChangesAsync();
                #endregion

                #region 2.先Blog,再保存BlogImage
                //var blog3 = new Blog
                //{
                //    Title = "Blog3",
                //    Url = "http://www.cnblogs.com/Allen-Li/category/329682.html"
                //};
                //context.Blogs.Add(blog3);
                //await context.SaveChangesAsync();

                //var blogImage3 = new BlogImage { Caption = "Image3", Image = new byte[20], BlogId = blog3.BlogId };
                //context.BlogImages.Add(blogImage3);
                //await context.SaveChangesAsync();
                #endregion

                #region 3.Blog和BlogImage一起保存
                //var blog4 = new Blog
                //{
                //    Title = "Blog4",
                //    Url = "http://www.cnblogs.com/Gyoung/tag/Entity%20Framework/",
                //    BlogImage = new BlogImage { Caption = "Image4", Image = new byte[50] }
                //};

                //var blog5 = new Blog
                //{
                //    Title = "Blog5",
                //    Url = "http://www.cnblogs.com/Gyoung/tag/Entity%20Framework/",
                //    BlogImage = new BlogImage { Caption = "Image5", Image = new byte[50] }
                //};
                //context.Blogs.Add(blog4);
                //context.Blogs.Add(blog5);
                //await context.SaveChangesAsync();
                #endregion

                #region 4.单独保存BlogImage
                //var blogImage1 = new BlogImage { Caption = "Image1", Image = new byte[200] };
                //context.BlogImages.Add(blogImage1);
                //await context.SaveChangesAsync();
                #endregion

                #region 5.单独保存Blog
                //var blog1 = new Blog
                //{
                //    Title = "Blog1",
                //    Url = "http://blog1"
                //};
                //context.Blogs.Add(blog1);
                //await context.SaveChangesAsync();
                #endregion

                #region 6.Title重复(Unique Constraints)
                //var blog6 = new Blog
                //{
                //    Title = "Blog5",
                //    Url = "http://Blog5/",
                //    BlogImage = new BlogImage { Caption = "Image4", Image = new byte[50] }
                //};
                //context.Blogs.Add(blog6);
                //await context.SaveChangesAsync();
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

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

            #region 删除
            try
            {
                #region 全部删除
                //context.Database.OpenConnection();
                //await context.Database.ExecuteSqlCommandAsync("DELETE FROM BlogImage");
                //await context.Database.ExecuteSqlCommandAsync("DELETE FROM Blog");
                //context.Database.CloseConnection();
                #endregion

                //1.单独删除BlogImage
                //var sroredBlogImage1 = await context.BlogImages.FirstOrDefaultAsync(bi => bi.BlogImageId == 10);
                //var blogId1 = sroredBlogImage1.BlogId;
                //if (sroredBlogImage1 != null)
                //{
                //    context.BlogImages.Remove(sroredBlogImage1);
                //    await context.SaveChangesAsync();
                //}

                //2.先删除BlogImage，再删除Blog
                //var sroredBlogImage2 = await context.BlogImages.FirstOrDefaultAsync(bi => bi.BlogImageId == 13);
                //var blogId2 = sroredBlogImage2.BlogId;
                //if (sroredBlogImage2 != null)
                //{
                //    context.BlogImages.Remove(sroredBlogImage2);
                //    await context.SaveChangesAsync();

                //    var sroredBlog2 = await context.Blogs.FirstOrDefaultAsync(b => b.BlogId == blogId2);
                //    if (sroredBlog2 != null)
                //    {
                //        context.Blogs.Remove(sroredBlog2);
                //        await context.SaveChangesAsync();
                //    }
                //}

                //3.删除Blog,自动删除BlogImage
                //var sroredBlog3 = await context.Blogs.Include(b => b.BlogImage).Where(b => b.BlogId == 2).FirstOrDefaultAsync();
                //if (sroredBlog3 != null)
                //{
                //    context.Blogs.Remove(sroredBlog3);
                //    await context.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region 读取
            //var task1 = System.Threading.Tasks.Task.Run(async () =>
            //  {
            //      var blogs = from b in context.Blogs.Include(b => b.BlogImage)
            //                  select b;
            //    //var blogs = from b in context.Blogs
            //    //            select new { Title = b.Title, ImageCaptiop = b.BlogImage.Caption, ImageLength = b.BlogImage.Image.Length };

            //    await blogs.ForEachAsync(blog =>
            //      {
            //          Console.WriteLine($"Blog: {blog.Title}");
            //          string imageCaptiop = blog.BlogImage != null ? blog.BlogImage.Caption : "\"No BlogImage Caption\"";
            //          int imageLength = blog.BlogImage != null ? blog.BlogImage.Image.Length : 0;
            //          Console.WriteLine($"ImageCaptiop: { imageCaptiop}, ImageSize {imageLength} bytes");
            //      });
            //  });

            //var task2 = System.Threading.Tasks.Task.Run(async () =>
            //{
            //    var blogs = from b in context.Blogs
            //                from bi in context.BlogImages
            //                where b.BlogId == bi.BlogId
            //                select b;
            //    await blogs.ForEachAsync(blog =>
            //    {
            //        Console.WriteLine($"Blog: {blog.Title}");
            //        string imageCaptiop = blog.BlogImage != null ? blog.BlogImage.Caption : "\"No BlogImage Caption\"";
            //        int imageLength = blog.BlogImage != null ? blog.BlogImage.Image.Length : 0;
            //        Console.WriteLine($"ImageCaptiop: { imageCaptiop}, ImageSize {imageLength} bytes");
            //    });
            //});

            //await System.Threading.Tasks.Task.WhenAll(task1, task2);
            #endregion

            context.Dispose();

            //foreach (var blog in blogs)
            //{
            //    Console.WriteLine($"Blog: {blog.Title}");
            //    Console.WriteLine($"ImageCaptiop: {blog.ImageCaptiop}, ImageSize {blog.ImageLength} bytes");
            //}
        }

        public async void StudentTesterOneToZeroOrOne()
        {
            var context = new EFCoreStoreContext();

            #region 保存
            try
            {
                //    //Student和StudentAddress必需一起保存
                //    var student1 = new Student
                //    {
                //        Name = "Student1",
                //        Address = new StudentAddress { Contry = "Contry1", State = "State1", City = "City1", Address1 = "Address1", Address2 = null, PostCode = null }
                //    };

                //    var address2 = new StudentAddress { Contry = "Contry2", State = "State2", City = "City2", Address1 = "Address1", Address2 = null, PostCode = "PostCode2" };
                //    var student2 = new Student
                //    {
                //        Name = "Student2",
                //        Address = address2
                //    };

                //    var student3 = new Student
                //    {
                //        Name = "Student3",
                //        Address = new StudentAddress { Contry = "Contry3", State = "State3", City = "City3", Address1 = "Address3", Address2 = null, PostCode = null }
                //    };

                //    var student4 = new Student
                //    {
                //        Name = "Student4",
                //        Address = new StudentAddress { Contry = "Contry4", State = "State4", City = "City4", Address1 = "Address4", Address2 = null, PostCode = null }
                //    };

                //单独保存Student
                //Address = new StudentAddress { Contry = "Contry5", State = "State5", City = "City5", Address1 = "Address5", Address2 = null, PostCode = "PostCode5" }
                //var student5 = new Student
                //{
                //    Name = "Student5"
                //};
                //context.Students.Add(student5);
                //await context.SaveChangesAsync();

                //    context.Students.Add(student1);
                //    context.Students.Add(student2);
                //    context.Students.Add(student3);
                //    context.Students.Add(student4);
                //    await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region  更新
            //Student updateStudent = null;
            //try
            //{
            //    updateStudent = await (from stu in context.Students.Include(s => s.Address)
            //                           where stu.StudentId == 1
            //                           select stu).FirstOrDefaultAsync();
            //    if (updateStudent != null)
            //    {
            //        updateStudent.Name = "UpdateStudent1";
            //        updateStudent.Address.Address1 = "UpdateAddress1";
            //        updateStudent.Address.Address2 = null;
            //        context.Entry<Student>(updateStudent).State = EntityState.Modified;
            //        await context.SaveChangesAsync();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            #endregion

            #region 删除
            //try
            //{
            //    var sroredStudent = await context.Students.FirstOrDefaultAsync(stu => stu.StudentId ==2);
            //    if (sroredStudent != null)
            //    {
            //        context.Students.Remove(sroredStudent);
            //        await context.SaveChangesAsync();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            #endregion

            try
            {
                //var students = from stu in context.Students
                //               select new { Name = stu.Name, Address = $"{ stu.Address.Contry }-{ stu.Address.State}-{ stu.Address.City}-{ stu.Address.Address1}-{ stu.Address.Address2?? "No Address2"}-{ stu.Address.PostCode?? "No PostCode"}" };

                //await students.ForEachAsync(stu =>
                //{
                //    Console.WriteLine($"Name: {stu.Name}");
                //    Console.WriteLine($"Address: {stu.Address}");
                //});

                //var students = from stu in context.Students
                //               select new { Name = stu.Name, Contry = stu.Address.Contry, State = stu.Address.State, City = stu.Address.City, Address1 = stu.Address.Address1, Address2 = stu.Address.Address2, PostCode = stu.Address.PostCode };
                //var students = from stu in context.Students.Include(s => s.Address)
                //               select stu;

                //await students.ForEachAsync(stu =>
                //{
                //    Console.WriteLine($"Name: {stu.Name}");
                //    Console.WriteLine($"{ stu.Address.Contry }-{  stu.Address.State}-{  stu.Address.City}-{  stu.Address.Address1}-{ stu.Address.Address2 ?? "\"No Address2\""}-{ stu.Address.PostCode ?? "\"No PostCode\""}");
                //});

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            context.Dispose();
        }

        public async void PhotographTesterOneToOne()
        {
            var context = new EFCoreStoreContext();

            #region 保存
            #endregion
            try
            {
                //byte[] thumbBits = new byte[100];
                //byte[] fullBits = new byte[2000];
                //var photograph1 = new Photograph
                //{
                //    Title = "Photograph1",
                //    ThumbnailBits = thumbBits,
                //    PhotographFullImage = new PhotographFullImage { HighResolutionBits = fullBits }
                //};

                //var photograph2 = new Photograph
                //{
                //    Title = "Photograph2",
                //    ThumbnailBits = new byte[100],
                //    PhotographFullImage = new PhotographFullImage { HighResolutionBits = new byte[2000] }
                //};

                //context.Photographs.Add(photograph1);
                //context.Photographs.Add(photograph2);
                //await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #region 更新
            Photograph updatePhotograph = null;
            try
            {
                //updatePhotograph = await (from p in context.Photographs.Include(p=> p.PhotographFullImage)
                //                       where p.PhotoId == 1
                //                       select p).FirstOrDefaultAsync();
                //if (updatePhotograph != null)
                //{
                //    updatePhotograph.Title= "UpdatedPhotograph1";
                //    updatePhotograph.PhotographFullImage.HighResolutionBits = new byte[2001];
                //    context.Entry<Photograph>(updatePhotograph).State = EntityState.Modified;
                //    await context.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            #region 删除
            try
            {
                //var delPhotograph = await context.Photographs.FirstOrDefaultAsync(p => p.PhotoId == 2);
                //if (delPhotograph != null)
                //{
                //    context.Photographs.Remove(delPhotograph);
                //    await context.SaveChangesAsync();
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            try
            {
                //var photographs = from p in context.Photographs
                //                  select new { Title = p.Title, ThumbnailBitsLength = p.ThumbnailBits.Length, PhotographFullImage = p.PhotographFullImage.HighResolutionBits.Length };

                //foreach (var photo in photographs)
                //{
                //    Console.WriteLine($"Photo: {photo.Title}, ThumbnailSize {photo.PhotographFullImage} bytes");
                //    Console.WriteLine($"Photo: {0}, ThumbnailSize {photo.ThumbnailBitsLength} bytes");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            context.Dispose();
        }
    }
}
