using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace KeepClone
{
   
    [ServiceContract]
    public interface INotesService
    {

        [OperationContract]
        [WebGet(UriTemplate="GetAllNotes", ResponseFormat =WebMessageFormat.Json)]
        List<Note> GetAllNotes();


        [OperationContract]
        [WebGet(UriTemplate = "GetAllDiaries/{username}", ResponseFormat = WebMessageFormat.Json)]
        List<Diary> GetAllDiaries(string username);

        [OperationContract]
        [WebGet(UriTemplate = "GetNotesByDiaryId/{diaryId}", ResponseFormat = WebMessageFormat.Json)]
        List<Note> GetNotesByDiaryId(string diaryId);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "AddDiary/{name}/{username}", ResponseFormat = WebMessageFormat.Json)]
        void AddDiary(string name, string username);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "UpdateNote/{id}/{newContent}")]
        void UpdateNoteContent(string id, string newContent);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "AddNote/{diaryid}/{name}", ResponseFormat = WebMessageFormat.Json)]
        void AddNote(string name, string diaryid);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "DeleteNote/{noteid}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteNote(string noteid);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "DeleteDiary/{diaryid}", ResponseFormat = WebMessageFormat.Json)]
        void DeleteDiary(string diaryid);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "AddUser/{username}/{password}", ResponseFormat = WebMessageFormat.Json)]
        void AddUser(string username, string password);

        [OperationContract]
        [WebGet(UriTemplate = "GetAllUsers", ResponseFormat = WebMessageFormat.Json)]
        List<User> GetAllUsers();

        [OperationContract]
        [WebGet(UriTemplate = "GetNoteById/{noteid}", ResponseFormat = WebMessageFormat.Json)]
        List<Note> GetNoteById(string noteid);
    }


}
