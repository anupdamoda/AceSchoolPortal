using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AceSchoolPortal.ViewModels
{
    public class ClassGradesModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Class_Grade_Id { get; set; }
        public string Class_Grade_Name { get; set; }
       
    }
}
