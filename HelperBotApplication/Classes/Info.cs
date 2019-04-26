using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperBotApplication
{
	public class Module
	{
		public String name { get; set; }
		public int credits { get; set; }
		public String prof { get; set; }
		public String exam { get; set; }
		public String winterTime { get; set; }
		public String summerTime { get; set; }
		public String description { get; set; }
		public String moduleType { get; set; }
	}

    public class CourseOverview
    {
        public String courseName { get; set; }
        public String shortDescription { get; set; }
        public String degreeOffered { get; set; }
        public int totalCreditPoints { get; set; }
        public String studyDuration { get; set; }
        public String startingDate { get; set; }
        public String studyModel { get; set; }
        public String language { get; set; }
        public String fees { get; set; }
    }

    public class AdmissionRequirement
    {
        public String name { get; set; }
        public String requiredUndergraduateDegree { get; set; }
        public String underGradEcts { get; set; }
        public String technicalRequirements { get; set; }
        public String toefl { get; set; }
        public String ielts { get; set; }

    }

    public class Professor
    {
        public String name { get; set; }
        public String designation { get; set; }
        public String module { get; set; }
        public String specialization { get; set; }
    }

    public class Prospect
    {
        public String name { get; set; }
        public String description { get; set; }
        public String companies { get; set; }
        public String positions { get; set; }
    }

    public class AdmissionDocuments
    {
        public String name { get; set; }
        public String documents { get; set; }
    }
    public class StudentReviews
    {
        public String name { get; set; }
        public String studentName { get; set; }
        public String review { get; set; }
        public String yearOfGraduation { get; set; }
    }

    public class Contact
    {
        public String name { get; set; }
        public String contactName { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String address { get; set; }
    }

    public class Sugg
    {
        public String name { get; set; }
        public List<String> sugestions { get; set; }
        public Sugg(String name,List<String> sugestions)
        {
            this.name = name;
            this.sugestions = sugestions;
        }
        

    }



    

}
