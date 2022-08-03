﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal interface IStorage<T> where T:IGood
    {
        public void Add(T item);
        public void Remove(T item);
    }
}
