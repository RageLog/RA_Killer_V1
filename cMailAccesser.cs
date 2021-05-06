using System;
using System.Threading.Tasks;

//SQLite
using System.Data.SQLite;


//Outlook
using OutLook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
using System.IO;

namespace RA_Killer_V1
{
    class cMailAccesser
    {
        private OutLook.Application m_Application;
        private OutLook._NameSpace outlookNS;
        OutLook.Folders mainFolders;
        
        public OutLook.Application getApplication() => m_Application;
        public cMailAccesser()
        {
            m_Application = new OutLook.Application();
            outlookNS = m_Application.GetNamespace("MAPI"); 
             mainFolders = outlookNS.Folders as OutLook.Folders;
            
        }
        public void saveAttachment(String  Path, OutLook.Attachment attachment)
        {
            attachment.SaveAsFile(Path + attachment.FileName);
        }
        public void saveAllAttachment(String Path, cMail mailItem)
        {
            foreach (var attachment in mailItem.Attachments)
            {
                attachment.SaveAsFile(Path + attachment.FileName);
            }
        }
        public void trevalMailItemsParallel(Action<cMail, OutLook.MAPIFolder, OutLook.MAPIFolder> func) 
        {
            if (func is null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            Parallel.ForEach(mainFolders, folder  =>
            {
                Parallel.ForEach(folder.Folders, subFolder => {
                    foreach (var item in subFolder.Items) {
                        if ((item != null) && (item is OutLook.MailItem))
                        {
                             func(new cMail(item as OutLook.MailItem), folder, subFolder);
                        }
                            
                    }
                });
            });
                
        }
        /*public void start() {


            try {

               string sender, to, CC, body, subject;
               string attpath;

                void func(cMail mailItem, OutLook.MAPIFolder folder,  OutLook.MAPIFolder subFolder)
                {
                   
                        if (mailItem.UnRead)
                        {
                            System.Console.WriteLine("\n" + folder.Name + " : " + subFolder.Name + "\n\n\n");
                            sender = mailItem.SenderName;
                            body = mailItem.Body;
                            subject = mailItem.Subject;
                            to = mailItem.To;
                            CC = mailItem.CC;
                            System.Console.WriteLine("Sender: " + sender);
                            System.Console.WriteLine("To: " + to);
                            System.Console.WriteLine("CC: " + CC);
                            System.Console.WriteLine("Subject: " + subject);
                            System.Console.WriteLine("Body: \n" + body);
                            //mailItem.UnRead = false;

                            //System.Console.WriteLine("Please enter the path");
                            //attpath = System.Console.ReadLine();
                           // saveAllAttachment(attpath, mailItem);
                        }
                    
                }
                trevalMailItemsParallel(func);

            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }*/



    }
}
