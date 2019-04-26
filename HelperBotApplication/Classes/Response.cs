using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperBotApplication
{
    public class Response
    {
        String response;
        public Response()
        {
            response = "";
        }
        internal String Answer_Module(HelperBotApplication.Module module)
        {
            response = module.name + "\n\n" + "This module is taught by " + module.prof + " and is of " + module.credits + " credit points. Important topics covered in this module are " + module.description + ".";
            if (module.summerTime == module.winterTime)
                response += "For both batches joining in summer and winter semester, this module takes place between " + module.winterTime;
            else
                response += "For the batch joining in winter semester, this module will take place between " + module.winterTime + " and for those joining in summer semester, it would be between " + module.summerTime;
            if (module.moduleType == "Regular Module")
                response += "This is one of the necessary modules you need to complete in order for successful completion of your degree. ";
            else
                response += "This comes under the specialization of " + module.moduleType + ". Out of the 3 elective modules, you need to complete atleast 2 modules of " + module.moduleType + " in order to get that specialization degree.";
            response += " Common assessment methods for this module are " + module.exam;

            return response;
        }
        internal String Answer_CourseOverview(CourseOverview courseOverview)
        {
            
            response = courseOverview.courseName;
            response += "\n\n " + courseOverview.shortDescription+"\n"+"The degree offered is "+courseOverview.degreeOffered+"\n"+"The total credit points in the course is "+courseOverview.totalCreditPoints+" and is "+courseOverview.studyDuration+" years long. The summer term starts in "+courseOverview.startingDate.Split(',')[1]+" and the winter term begins in "+ courseOverview.startingDate.Split(',')[0]+". The course is "+courseOverview.studyModel+" and is taught completely in "+courseOverview.language+"\n\n"+"An overview of the fees can be found below\n"+courseOverview.fees;
            return response;
        }

        internal String Answer_Professor(Professor professor)
        {
            response = professor.name;
            response += "\n\n"+professor.designation+" "+professor.name+" teaches "+professor.module+". Topics of interests include "+professor.specialization;
            return response;
        }
        internal String Answer_Prospect(Prospect prospect)
        {
            response = prospect.name;
            response += "\n\n" +prospect.description+"\nSome top companies where our students work are "+prospect.companies+"\nPositions our students are qualified to work are "+prospect.positions;
            return response;
        }
        internal String Answer_AdmissionDocuments(AdmissionDocuments admissionDocuments)
        {
            response = admissionDocuments.name;
            response += "\n\n" + "The following documents are required while applying for our course" + "\n" + admissionDocuments.documents;
            return response;
        }
        internal String Answer_StudentReviews(StudentReviews studentReviews)
        {
            response = studentReviews.name+" by "+studentReviews.studentName;
            response += "\n\n" +"Hi My name is "+studentReviews.studentName+". I graduated in "+studentReviews.yearOfGraduation+". "+studentReviews.review;
            return response;
        }
        internal String Answer_Contact(Contact contact)
        {
            response = contact.name;
            response += "\n\nName: "+contact.name+"\nEmail: "+contact.email+"\nPhone: "+contact.phone+"\nAddress: "+contact.address;
            return response;
        }
        internal String Answer_AdmissionRequirement(AdmissionRequirement admissionRequirement)
        {
            response = admissionRequirement.name;
            response += "\n\nInterested students must have a " + admissionRequirement.requiredUndergraduateDegree + "having " + admissionRequirement.underGradEcts + "They should have a " + admissionRequirement.technicalRequirements + ". A TOEFL score higher than  " + admissionRequirement.toefl + " or an IELTS score higher than " + admissionRequirement.ielts + " is accepted";
            return response;
        }

    }
}
