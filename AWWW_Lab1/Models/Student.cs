using AWWW_Lab1.Interfaces;

namespace AWWW_Lab1.Models {
    public class Student: IModel{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int indexNumber { get; set; }
        public DateTime birthDate { get; set; }
        public string Faculty { get; set; }
    }
}
