﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using LibraryWithSDKandRefitService;
using Refit;

namespace ConsoleSampleUsingLocalApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HttpClient _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com")
            };
            
            IRestService _restApiService = RestService.For<IRestService>(_client);

            while (true)
            {
                Console.WriteLine("Enter from the following numbers to access the APIs,\n1 for get ,\n2 for get with argument, \n3 for post,\n4 for put, \n5 for Delete \n");
                int choice = Int32.Parse(Console.ReadLine() ?? "6");
                switch (choice)
                {
                    case 1:
                        var result1 = _restApiService.GetWithNoParameter();
                        Console.WriteLine(result1);
                        break;
                    case 2:
                        var result2 = _restApiService.GetWithParameter(4);
                        Console.WriteLine(result2);
                        break;
                    case 3:
                        var result3 = _restApiService.PostWithTestObject(new ModelForTest());
                        Console.WriteLine(result3);
                        break;
                    case 4:
                        var result4 = _restApiService.PutWithParameters(4, new ModelForTest());
                        Console.WriteLine(result4);
                        break;
                    case 5:
                        var result5 = _restApiService.DeleteWithParameters(5);
                        Console.WriteLine(result5);
                        break;
                    default:
                        Console.WriteLine("Bhai Please Enter valid if you are really serious");
                        break;
                }
            }
        }
    }
}
