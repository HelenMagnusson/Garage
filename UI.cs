using Garage.Common;
using System;
using System.Collections.Generic;

namespace Garage
{
    public class UI : IUI
    {
        public void ShowMessage(string s)
        {
            Console.WriteLine(s);
        }


    }
}