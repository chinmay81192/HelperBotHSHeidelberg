using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManageStudents;


namespace HelperBotApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ArrayList info = new ArrayList();
        ObservableCollection<Module> modules;
        ObservableCollection<Sugg> options;
        List<Type> listOfClasses = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "HelperBotApplication").ToList();
        
        public MainWindow()
        {
            InitializeComponent();
            readfromXML();
            //List<String> suggestions = new List<String>{"Specializations", "Specialization <Name> Modules","Professors","Professor <Name>","Professor <Name> Modules" };
            
            options = new ObservableCollection<Sugg>();
            Sugg s = new Sugg("Module", new List<string> { "Modules", "Module <Module>", "Modules Professor <Name> ", "Modules Specialization", "Modules <Specialization>" });
            options.Add(s);
            

        }

        private Type getClass(Type comp)
        {
            var listOfClasses = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "HelperBotApplication").ToList();
            foreach (var clas in listOfClasses)
            {
                if (comp.ToString().ToLower().Contains(clas.ToString().ToLower()))
                {
                    Console.WriteLine("FOUND");
                    
                    return clas;
                }

            }
            return typeof(Nullable);
        }

        private void ReadIntoListBox()
        {
            ArrayList infoList = new ArrayList();
            foreach (var item in info)
            {
                Type type = getClass(item.GetType());
                if(type == typeof(Nullable))
                {
                    continue;
                }
                IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());
                Console.WriteLine(props.Count);
                foreach (var i in (dynamic)item)
                {
                    foreach (PropertyInfo property in props)
                    {
                        try
                        {
                            if (property.GetValue(i, null).ToString().ToLower().Contains(Query.Text.ToLower()) || property.Name.ToString().ToLower().Contains(Query.Text.ToLower()) || Query.Text.ToLower().Contains(property.Name.ToString().ToLower()) || Query.Text.ToLower().Contains(property.GetValue(i,null).ToString().ToLower()) || property.GetValue(i, null).ToString().ToLower().Contains(Query.Text.ToLower()))
                            {
                                infoList.Add(i);
                                break;
                            }
                        }
                        catch(Exception)
                        {
                            continue;
                        }
                    }
                }
            }
            Suggestions.ItemsSource = infoList;
        }

        private void readfromXML()
        {
            info.Add(MyStorage.ReadXML<ObservableCollection<Module>>("modules.xml"));
            info.Add(MyStorage.ReadXML<ObservableCollection<Module>>("modules.xml"));
            info.Add(MyStorage.ReadXML<ObservableCollection<CourseOverview>>("courseOverview.xml"));
            info.Add(MyStorage.ReadXML<ObservableCollection<Professor>>("profs.xml"));
            info.Add(MyStorage.ReadXML<ObservableCollection<AdmissionRequirement>>("admissionRequirements.xml"));
            info.Add(MyStorage.ReadXML<ObservableCollection<Prospect>>("prospects.xml"));
            info.Add(MyStorage.ReadXML<ObservableCollection<AdmissionDocuments>>("admissionDocuments.xml"));
            info.Add(MyStorage.ReadXML<ObservableCollection<StudentReviews>>("studentReviews.xml"));
            info.Add(MyStorage.ReadXML<ObservableCollection<Contact>>("contact.xml"));
        }

        private void Query_TextChanged(object sender, TextChangedEventArgs e)
        {
            Suggestions.SelectedIndex = -1;
            if (Query.Text == "")
            {
                Suggestions.ItemsSource = "";
                Answer.Text = "I hope that I have assisted you in your query. What else would you like to search for?";
            }
            else
            {
                if (Query.Text.Split().Length > 4)
                {
                    Answer.Text = "Hey! try keeping your question short . Long sentences never help";
                }
                else {
                    ReadIntoListBox();
                    int length = Suggestions.Items.Count;
                    if (length == 0)
                    {
                        Answer.Text = "Sorry! I am not able to find results matching " + Query.Text + "\n You can try rephrasing the question";
                    }
                    else
                    {
                        Answer.Text = "I have found " + length + " different results matching " + Query.Text + "\n Please select the option you would like to explore in detail";
                    }
                }
            }        
        }


        private void Suggestions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Suggestions.SelectedIndex == -1)
                return;




            try
            {
                Answer.Text = "";
                Type t = getClass(Suggestions.SelectedItem.GetType());
                Response res = new Response();
                if (t.ToString().ToLower().Contains("Module".ToLower()))
                {
                    var module = new Module();
                    module = (Module)Suggestions.SelectedItem;
                    Answer.Text = res.Answer_Module(module);
                }
                else if (t.ToString().ToLower().Contains("CourseOverview".ToLower()))
                {
                    var courseOverview = new CourseOverview();
                    courseOverview = (CourseOverview)Suggestions.SelectedItem;
                    Answer.Text = res.Answer_CourseOverview(courseOverview);
                }
                else if (t.ToString().ToLower().Contains("Professor".ToLower()))
                {
                    var professor = new Professor();
                    professor = (Professor)Suggestions.SelectedItem;
                    Answer.Text = res.Answer_Professor(professor);
                }
                else if (t.ToString().ToLower().Contains("Prospect".ToLower()))
                {
                    var prospect = new Prospect();
                    prospect = (Prospect)Suggestions.SelectedItem;
                    Answer.Text = res.Answer_Prospect(prospect);
                }
                else if (t.ToString().ToLower().Contains("AdmissionDocuments".ToLower()))
                {
                    var admissionDocuments = new AdmissionDocuments();
                    admissionDocuments = (AdmissionDocuments)Suggestions.SelectedItem;
                    Answer.Text = res.Answer_AdmissionDocuments(admissionDocuments);
                }
                else if (t.ToString().ToLower().Contains("StudentReviews".ToLower()))
                {
                    var studentReviews = new StudentReviews();
                    studentReviews = (StudentReviews)Suggestions.SelectedItem;
                    Answer.Text = res.Answer_StudentReviews(studentReviews);
                }
                else if (t.ToString().ToLower().Contains("Contact".ToLower()))
                {
                    var contact = new Contact();
                    contact = (Contact)Suggestions.SelectedItem;
                    Answer.Text = res.Answer_Contact(contact);
                }
                else if (t.ToString().ToLower().Contains("AdmissionRequirement".ToLower()))
                {
                    var admissionRequirement = new AdmissionRequirement();
                    admissionRequirement = (AdmissionRequirement)Suggestions.SelectedItem;
                    Answer.Text = res.Answer_AdmissionRequirement(admissionRequirement);
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        
    }
}
