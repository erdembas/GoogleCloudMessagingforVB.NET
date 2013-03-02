Imports System.Net
Imports System.IO

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Public Sub KomutGonder(ByVal sCommand As String)
        Dim DeviceID As String = ""
        DeviceID = "APA91bGl0UAifOmqMVgWEm-HbFlipxBwU96A6GvsWt-sxEVC_8JFiI3wrahzCuB0EP91Rt9Y2OP0OK1VrbPETbwp--D-zrJom-OO3LObf1OLlsX52VsqjgP5pXOME7B0Z5v3iB6LBQ8ssBkNn8Uml8n2sD9qC9K3Gw"

        Dim tRequest As WebRequest
        tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send")
        tRequest.Method = "post"
        tRequest.ContentType = "application/x-www-form-urlencoded"
        tRequest.Headers.Add(String.Format("Authorization: key={0}", "AIzaSyAbT4-ojbhZt35lrIqjJz2ZHKlDCkXfZTE"))


        Dim collaspeKey As [String] = Guid.NewGuid().ToString("n")
        'String postData=string.Format("registration_id={0}&data.payload={1}&collapse_key={2}", DeviceID, "Pickup Message", collaspeKey);

        Dim postData As [String] = String.Format("registration_id={0}&data.content={1}&collapse_key={2}", DeviceID, sCommand, collaspeKey)

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
    End Sub

    Function Index() As ActionResult
        ViewData("Message") = "Modify this template to jump-start your ASP.NET MVC application."
        KomutGonder("Ilk mesaj gönderimi")
        Return View()
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
