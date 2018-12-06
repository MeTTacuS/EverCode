using System;
using System.IO;
using System.Windows;

namespace PersonManager.Utils
{
   internal class PersonsPersistence
   {
      public const string DefaultExtension = ".jpg";

      public static bool AddPersonGroup(string personGroupId)
      {
         try
         {
            Directory.CreateDirectory(Path.Combine(AppSettings.PersonGroupBaseFolder, personGroupId));
            return true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }

         return false;
      }

      public static bool DeletePersonGroup(string personGroupId)
      {
         try
         {
            Directory.Delete(Path.Combine(AppSettings.PersonGroupBaseFolder, personGroupId), true);
            return true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }

         return false;
      }

      public static bool AddPersonInGroup(string personGroupId, string personId)
      {
         try
         {
            Directory.CreateDirectory(
               Path.Combine(AppSettings.PersonGroupBaseFolder, 
               Path.Combine(personGroupId, personId)));
            return true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }

         return false;
      }

      public static bool DeletePersonInGroup(string personGroupId, string personId)
      {
         try
         {
            Directory.Delete(
               Path.Combine(AppSettings.PersonGroupBaseFolder, 
                  Path.Combine(personGroupId, personId)), 
               true);
            return true;
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }

         return false;
      }

      public static string AddFaceToPerson(string personGroupId, string personId, string persistedFaceId, string path)
      {
         if (!string.IsNullOrEmpty(persistedFaceId) &&
            !string.IsNullOrEmpty(personGroupId) && 
            !string.IsNullOrEmpty(personId))
         {
            var destination = 
               Path.Combine(
                  Path.Combine(
                     AppSettings.PersonGroupBaseFolder, 
                     Path.Combine(personGroupId, personId)),
                  persistedFaceId + Path.GetExtension(path));

            File.Copy(path, destination);

            return destination;
         }

         return null;
      }

      public static bool RemoveFaceFromPerson(string personGroupId, string personId, string persistedFaceId)
      {
         if (!string.IsNullOrEmpty(persistedFaceId) &&
            !string.IsNullOrEmpty(personGroupId) &&
            !string.IsNullOrEmpty(personId))
         {
            File.Delete(Path.Combine(
               Path.Combine(AppSettings.PersonGroupBaseFolder, 
                  Path.Combine(personGroupId, personId)),
               persistedFaceId + DefaultExtension));

            return true;
         }

         return false;
      }

      public static FileInfo[] GetFaceFiles(string personGroupId, string personId)
      {
         var dir = new DirectoryInfo(
            Path.Combine(AppSettings.PersonGroupBaseFolder, 
                         Path.Combine(personGroupId, personId)));

         var files = dir.GetFiles("*" + DefaultExtension);
         return files;
      }
   }
}
