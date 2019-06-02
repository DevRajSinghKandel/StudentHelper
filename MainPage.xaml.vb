Imports Windows.UI.Popups
Imports Windows.Storage
Imports Windows.Storage.Streams
Imports Windows.Networking.BackgroundTransfer

' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Dim saniza As New MessageDialog("")


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Direct admiration
        reloading()



    End Sub


    Public Async Sub reloading()
        'Checking the whole of filesystem
        'Get all the files name and all the details
        'Try to get all the files
        Dim kamona As New ObservableCollection(Of finaldisplay
            )

        Dim yuin As IReadOnlyList(Of StorageFile) = Await ApplicationData.Current.LocalFolder.GetFilesAsync()

        For Each eras As StorageFile In yuin



            Dim varil As New finaldisplay
            varil.realname = eras.DisplayName
            varil.set3differet()
            kamona.Add(varil)















        Next

        Mainpalette.DataContext = kamona




    End Sub



    'Trying to downlaod the data

    Public Async Sub initiazt()
        'Use networking apis
        'Getting the file

        Dim k As New filenamer
        If A1.SelectedIndex = 0 Then
            k.aname = "P"
        Else
            k.aname = "C"
        End If


        If A2.SelectedIndex = 0 Then
            k.bname = "M"
        Else
            k.bname = "O"
        End If
        If A3.SelectedIndex = 0 Then
            k.cname = "1"

        Else
            k.cname = "2"
        End If
        Dim finallu = k.returnfinal

        'Check whether such file exists or not
        Dim ramnam As StorageFile
        ramnam = Await Windows.Storage.ApplicationData.Current.LocalFolder.TryGetItemAsync(finallu)
        Dim flan As New Uri("http://devos.000webhostapp.com/" + finallu)
        If ramnam Is Nothing Then


            'try to manage the downlaod

            Dim vn As StorageFile = Await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(finallu)
            Dim sanonfal As New BackgroundDownloader()
            Dim rf As DownloadOperation = sanonfal.CreateDownload(flan, vn)

            Await rf.StartAsync()

            Await Windows.System.Launcher.LaunchFileAsync(rf.ResultFile)

            saniza.Content = "File has been downloaded and is now opened for you"









        Else


            Await Windows.System.Launcher.LaunchFileAsync(ramnam)
            saniza.Content = "File was already downloaded and is now opened for you"

        End If
        Await saniza.ShowAsync()



    End Sub






    Private Sub Downloader_Click(sender As Object, e As RoutedEventArgs) Handles Downloader.Click
        'trying to understand the default version
        initiazt()


    End Sub

    Private Sub Reloader_Click(sender As Object, e As RoutedEventArgs) Handles Reloader.Click
        'Try to reload the data source
        reloading()


    End Sub

    Private Async Sub Mainpalette_ItemClick(sender As Object, e As ItemClickEventArgs) Handles Mainpalette.ItemClick



        Dim efman As finaldisplay = e.ClickedItem
        Dim derivation = efman.realname + ".pdf"
        Dim karnol As StorageFile = Await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(derivation)

        Await Windows.System.Launcher.LaunchFileAsync(karnol)


    End Sub
End Class
'Class for decoding the data
Public Class filenamer
    Public aname As String
    Public bname As String
    Public cname As String

    Public Function returnfinal() As String
        Dim q As String = aname + bname + cname + ".pdf"
        Return q
    End Function
End Class


Class finaldisplay
    Public Property realname As String
    Public Property SubImage As BitmapImage
    Public Property Subject As String
    Public Property Paper As String
    Public Property Session As String


    Public Sub set3differet()
        If realname.Chars(0) = "P" Then
            Subject = "Physics"
            SubImage = New BitmapImage(New Uri("ms-appx:///Assets/Physics.jpeg"))
        Else
            Subject = "Chemistry"
            SubImage = New BitmapImage(New Uri("ms-appx:///Assets/chemistry.jpg"))
        End If


        If realname.Chars(1) = "M" Then
            Session = "May/June"
        Else
            Session = "October/November"
        End If

        If realname.Chars(2) = "1" Then
            Paper = "Paper1"
        Else
            Paper = "Paper2"
        End If
    End Sub



End Class