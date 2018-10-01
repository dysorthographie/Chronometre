Imports System

Public Class Chron
    Public Event Clear()
    Private D As Date, i As Integer = 1
    Public Property Afficher As Boolean
        Get
            Return Me.Visible
        End Get
        Set(value As Boolean)
            Me.Visible = value
        End Set
    End Property
    Public ReadOnly Property Temps As String
        Get
            Temps = Label1.Text
        End Get

    End Property


    Private Sub Chron_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        Timer1.Stop()
        Timer1.Interval = 5
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Controls("PictureBox" + i.ToString).Visible = False
        i += 1 : If i > 3 Then i = 1
        Controls("PictureBox" + i.ToString).Visible = True
        Select Case i
            Case 1 : Timer1.Stop()
            Case 2 : Label1.Text = "00:00:00,000" : RaiseEvent Clear()
            Case 3 : D = Date.Now : Timer1.Start()
                'Case 3 : D = DateTime.Parse("1/2/2018 00:00:00") : Timer1.Start()

        End Select
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = (Date.Now - D).ToString()
    End Sub

    Private Sub Chron_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Width = 373 : Height = 250
    End Sub
End Class
