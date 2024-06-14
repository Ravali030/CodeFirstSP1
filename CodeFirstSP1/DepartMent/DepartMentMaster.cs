using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSP1.DepartMent
{
    public class DepartMentMaster
    {
        [Key]
        public int Deptid {  get; set; }
        public string deptCode {  get; set; }
        public string DepartName { get; set;}

    }
}
