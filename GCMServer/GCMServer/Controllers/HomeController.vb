Imports System.Net
Imports System.IO

Public Class HomeController
    Inherits System.Web.Mvc.Controller
    Dim _Context As New GCMDatabaseEntities

    <HttpPost> <ValidateInput(False)>
    Public Function KomutGonder(RegID As String, sCommand As String) As String
        Try
            Dim tRequest As WebRequest
            tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send")
            tRequest.Method = "post"
            tRequest.ContentType = "application/x-www-form-urlencoded"
            tRequest.Headers.Add(String.Format("Authorization: key={0}", "AIzaSyAbT4-ojbhZt35lrIqjJz2ZHKlDCkXfZTE"))


            Dim collaspeKey As [String] = Guid.NewGuid().ToString("n")
            'String postData=string.Format("registration_id={0}&data.payload={1}&collapse_key={2}", DeviceID, "Pickup Message", collaspeKey);

            Dim postData As [String] = String.Format("registration_id={0}&data.content={1}&collapse_key={2}", RegID, sCommand, collaspeKey)

            Dim byteArray As [Byte]() = Encoding.UTF8.GetBytes(postData)
            tRequest.ContentLength = byteArray.Length

            Dim dataStream As Stream = tRequest.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim tResponse As WebResponse = tRequest.GetResponse()
            dataStream = tResponse.GetResponseStream()
            Dim tReader As New StreamReader(dataStream)
            Dim sResponseFromServer As [String] = tReader.ReadToEnd()
            tReader.Close()
            dataStream.Close()
            tResponse.Close()
            Return "Mesajınız Gönderildi"
        Catch ex As Exception
            Return "Bir Hata Oluştu"
        End Try
    End Function

    Function Index() As ActionResult
        Dim List = _Context.Kullanicis
        Return View(List)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your app description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
