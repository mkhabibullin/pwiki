using ProGaudi.Tarantool.Client;
using ProGaudi.Tarantool.Client.Model;
using ProGaudi.Tarantool.Client.Model.Enums;
using System;
using System.Threading.Tasks;

namespace TarantoolTests
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWork().Wait();

            Console.WriteLine("Done");
            Console.Read();
        }

        static async Task DoWork()
        {
            using (var box = await Box.Connect("operator:123123@localhost:3301"))
            {
                var schema = box.GetSchema();
                var space = await schema.GetSpace("users");
                var primaryIndex = await space.GetIndex("primary_id");
                var data = await primaryIndex.Select<TarantoolTuple<string>,
                            TarantoolTuple<string, string, string, string, long>>(
                            TarantoolTuple.Create(String.Empty), new SelectOptions
                            {
                                Iterator = Iterator.All
                            });
                foreach (var item in data.Data)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
