using System;
using System.Net.NetworkInformation;

namespace Northwind.Shared.Constants;

public class Routes
{
    public static class Api
    {
        public static class Employees
        {
            public const string GetAll = "api/employees";
            public const string GetById = "api/employees/{id:int}";
            public const string Add = "api/employees";
            public const string Update = "api/employees";
            public const string Delete = "api/employees/{id:int}";
        }
    }

    public static class Pages
    {
        public const string Home = "/";
        public const string Counter = "/counter";
        public const string Weather = "/weather";

        public static class Employees
        {
            public const string GetAllEmployees = "/employees";
        }
    }
}
