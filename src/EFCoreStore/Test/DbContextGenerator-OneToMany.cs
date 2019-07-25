//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace EFCoreStore.Models
//{
//    public partial class DbContextGenerator
//    {

//        public async void StoreOnetoManyTester()
//        {
//            var context = new EFCoreStoreContext();

//            #region 保存
//            try
//            {
//                #region 1.先保存Store,再保存Employee
//                var store1 = new Store { Name = "Store1" };
//                context.Stores.Add(store1);
//                await context.SaveChangesAsync();

//                var employee1 = new Employee {  Name = "Employee1" , Store= store1 };
//                context.Employees.Add(employee1);
//                await context.SaveChangesAsync();
//                #endregion

//                #region 2.先Employee,再保存Store
//                var employee2 = new Employee { Name = "Employee2" };
//                context.Employees.Add(employee2);
//                await context.SaveChangesAsync();

//                var store2 = new Store { Name = "Store2" };
//                store2.Employees.Add(employee2);
//                context.Stores.Add(store2);
//                await context.SaveChangesAsync();
//                #endregion

//                #region 5.Store和Employee一起保存
//                var store3 = new Store
//                {
//                    Name = "Store3",
//                    Employees = new List<Employee>
//                               {
//                                   new Employee { Name = "Employee3" },
//                                   new Employee { Name = "Employee4" }
//                                }
//                };
//                context.Stores.Add(store3);
//                await context.SaveChangesAsync();

//                var store4 = new Store
//                {
//                    Name = "Store4",
//                    Employees = new List<Employee>
//                                {
//                                   new Employee { Name = "Employee5" },
//                                   new Employee { Name = "Employee6" }
//                                 }
//                };
//                context.Stores.Add(store4);
//                await context.SaveChangesAsync();
//                #endregion

//                #region 6.单独保存Store
//                var store5 = new Store { Name = "Store5" };
//                context.Stores.Add(store5);
//                await context.SaveChangesAsync();
//                #endregion

//                #region 7.单独保存Employee
//                var employee3 = new Employee { Name = "Employee7" };
//                context.Employees.Add(employee3);
//                await context.SaveChangesAsync();
//                #endregion

//                #region 8.Name重复(Unique Constraints)
//                var store6 = new Store { Name = "Store1" };
//                context.Stores.Add(store6);
//                await context.SaveChangesAsync();
//                #endregion
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            #endregion

//            #region  更新
//            Store updateStore = null;
//            Employee updateEmployee = null;
//            try
//            {
//                //updateEmployee = await (from e in context.Employees
//                //                         where e.EmployeeId == 1
//                //                         select e).FirstOrDefaultAsync();
//                //if (updateEmployee != null)
//                //{
//                //    updateEmployee.Name= "UpdateName1";
//                //    context.Entry<Employee>(updateEmployee).State = EntityState.Modified;
//                //    await context.SaveChangesAsync();
//                //}

//                //updateStore = await (from s in context.Stores
//                //                    where s.StoreId== 7
//                //                    select s).FirstOrDefaultAsync();
//                //if (updateStore != null)
//                //{
//                //    updateStore.Name = "UpdateBlog2";
//                //    context.Entry<Store>(updateStore).State = EntityState.Modified;
//                //    await context.SaveChangesAsync();
//                //}
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            #endregion

//            #region 删除
//            try
//            {
//                #region 全部删除
//                //context.Database.OpenConnection();
//                //await context.Database.ExecuteSqlCommandAsync("DELETE FROM Employee");
//                //await context.Database.ExecuteSqlCommandAsync("DELETE FROM Store");
//                //context.Database.CloseConnection();
//                #endregion

//                ////1.单独删除一行Store2,無Employees
//                //var sroredStore1 = await context.Stores.FirstOrDefaultAsync(s => s.Name == "Store5");
//                //if (sroredStore1 != null)
//                //{
//                //    context.Stores.Remove(sroredStore1);
//                //    await context.SaveChangesAsync();
//                //}

//                ////2.单独删除一行Store2,有Employees
//                //var sroredStore2 = await context.Stores.FirstOrDefaultAsync(s => s.Name == "Store2");
//                //if (sroredStore1 != null)
//                //{
//                //    context.Stores.Remove(sroredStore1);
//                //    await context.SaveChangesAsync();
//                //}

//                ////3.单独删除一行Employee
//                //var sroredEmployee1 = await context.Employees.FirstOrDefaultAsync(e =>e.Name == "Employee7");
//                //var blogId1 = sroredEmployee1.StoreId;
//                //if (sroredEmployee1 != null)
//                //{
//                //    context.Employees.Remove(sroredEmployee1);
//                //    await context.SaveChangesAsync();
//                //}

//                ////4.删除Store2以及Employees
//                //var sroredStore3 = await context.Stores.Include(s=>s.Employees).FirstOrDefaultAsync(s => s.Name == "Store2");
//                //if (sroredStore3 != null)
//                //{
//                //    context.Stores.Remove(sroredStore3);
//                //    await context.SaveChangesAsync();
//                //}
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//            }
//            #endregion

//            #region 读取
//            var task1 = System.Threading.Tasks.Task.Run(async () =>
//            {
//                var stores = from b in context.Stores.Include(s =>s.Employees)
//                             select b;
              
//                await stores.ForEachAsync(store =>
//                {
//                    Console.WriteLine($"Store: {store.Name}");
//                    foreach (var e in store.Employees)
//                    {
//                        Console.WriteLine($"Employee: {store.Name}");
//                    }
//                });
//            });

//            var task2 = System.Threading.Tasks.Task.Run(async () =>
//            {
//                var stores = from b in context.Stores.Include(s => s.Employees)
//                             select b;

//                await stores.ForEachAsync(store =>
//                {
//                    Console.WriteLine($"Store: {store.Name}");
//                    foreach (var e in store.Employees)
//                    {
//                        Console.WriteLine($"Employee: {store.Name}");
//                    }
//                });
//            });

//            await System.Threading.Tasks.Task.WhenAll(task1, task2);
//            #endregion

//            context.Dispose();
//        }
//    }
//}
