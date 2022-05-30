﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_26_2022_EntityFramework
{
    internal class BookAnnualReport
    {
        public long BookId { get; set; }
        public string Title { get; set; }
        public int January { get; set; }
        public int February { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int September { get; set; }
        public int October { get; set; }
        public int November { get; set; }
        public int December { get; set; }

        public override string ToString()
        {
            return $"{BookId} {Title} {January} {February} " +
                    $"{March} {April} {May} {June} {July} {August} " +
                        $"{September} {October} {November} {December}";
        }
    }
}
