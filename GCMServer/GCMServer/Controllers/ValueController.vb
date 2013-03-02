Imports System.Net
Imports System.Web.Http

Public Class ValueController
    Inherits ApiController
    Dim _Context As New GCMDatabaseEntities
    ' GET api/value
    Public Function GetValues() As IEnumerable(Of String)
        Return New String() {"value1", "value2"}
    End Function

    ' GET api/value/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/value
    Public Function PostValue(ByVal value As Kullanici) As String
        Try
            _Context.Kullanicis.Add(value)
            _Context.SaveChanges()
            Return "True"
        Catch ex As Exception
            Return "False"
        End Try
    End Function

    ' PUT api/value/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/value/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
