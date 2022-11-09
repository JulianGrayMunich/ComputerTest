using databaseAPI;

using EASendMail;

//using GNAchartingtools;

using GNAgeneraltools;

//using GNAspreadsheettools;

//using GNAsurveytools;


//using OfficeOpenXml;

using System;
using System.Configuration;
using System.IO.Enumeration;
using System.Net.NetworkInformation;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;






namespace ComputerTest
{
    class Program
    {
        static void Main()
        {

            gnaTools gnaT = new gnaTools();
            //GNAsurveycalcs gnaSurvey = new GNAsurveycalcs();
            dbAPI gnaDBAPI = new dbAPI();
            //spreadsheetAPI gnaSpreadsheetAPI = new spreadsheetAPI();
            //GNAchartingAPI chartingAPI = new GNAchartingAPI();

            // Console settings
            Console.OutputEncoding = System.Text.Encoding.Unicode;

#pragma warning disable CS8600
#pragma warning disable CS8604
#pragma warning disable IDE0090
#pragma warning disable CS0164


            Console.WriteLine("Software to check the computer environment");
            Console.WriteLine("Press key to start test..");
            Console.ReadKey();
            Console.WriteLine("");

            string strDBconnection = ConfigurationManager.ConnectionStrings["DBconnectionString"].ConnectionString;
            string strProjectTitle = ConfigurationManager.AppSettings["ProjectTitle"];
            string strEmailLogin = ConfigurationManager.AppSettings["EmailLogin"];
            string strEmailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            string strEmailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            string strMailRecipients = ConfigurationManager.AppSettings["systemMailRecipients"];
            string strSendSMS = ConfigurationManager.AppSettings["SendSMS"];
            string strRecipientPhone1 = ConfigurationManager.AppSettings["RecipientPhone1"];
            string strRecipientPhone2 = ConfigurationManager.AppSettings["RecipientPhone2"];

            Console.WriteLine("Testing App.config Settings:");
            Console.WriteLine(strProjectTitle);
            Console.WriteLine(strDBconnection);


            Console.WriteLine("");
            Console.WriteLine("Contact with GNAlibrary:");

            gnaT.WelcomeMessage("hello world");

            Console.WriteLine("\nTesting 2 way comms with modules:");
            string strOutgoingMessage = "Outgoing Message";
            string strReceivingMessage = gnaT.check2wayComms(strOutgoingMessage);
            Console.WriteLine("Outgoing message: " + strOutgoingMessage);
            Console.WriteLine("Return message: " + strReceivingMessage);

            Console.WriteLine("\nTesting DB connection:");
            Console.WriteLine(strDBconnection);

            gnaDBAPI.testDBconnection(strDBconnection);

            Console.WriteLine("\nTesting sms:");
            string strMessage = "Test SMS";
            if (strSendSMS=="Yes")
            {
                Console.WriteLine(strMessage);
                gnaT.sendSMS(strMessage, strRecipientPhone1, strRecipientPhone2);
                Console.WriteLine("SMS sent..");
            }
            else
            {
                Console.WriteLine("SMS disabled, not sent");
            }

            Console.WriteLine("\nTesting email:");
            strMessage = "Test email";
            string strSubjectLine = "Subject Line : " + strProjectTitle + " test email";

            gnaT.sendEmail(strEmailLogin, strEmailPassword, strEmailFrom, strMailRecipients, strSubjectLine, strMessage);

            Console.WriteLine("\nTest complete");
            Console.WriteLine("Press key to close..");
            Console.ReadKey();

            Environment.Exit(0);

ThatsAllFolks:

            string strFreezeScreen = ConfigurationManager.AppSettings["freezeScreen"];

            if (strFreezeScreen == "Yes")
            {
                Console.WriteLine("freezeScreen set to Yes");
                Console.WriteLine("press key to exit..");
                Console.ReadKey();
            }

            Environment.Exit(0);
            Console.WriteLine("");
            Console.WriteLine("Task Complete....");

        }
    }
}