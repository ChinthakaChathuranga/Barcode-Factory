Imports WebCam_Capture
Imports MessagingToolkit.QRCode.Codec

Public Class Form1
    WithEvents mywebcam As WebCamCapture
    Dim reader As QRCodeDecoder

    Private Sub startwebcam()
        Try
            stopwebcam()
            mywebcam = New WebCamCapture
            mywebcam.Start(0)
            mywebcam.Start(0)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub stopwebcam()
        Try
            mywebcam.Stop()
            mywebcam.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub mywebcam_ImageCaptured(ByVal source As Object, ByVal e As WebCam_Capture.WebcamEventArgs) Handles mywebcam.ImageCaptured
        PictureBox2.Image = e.WebCamImage
    End Sub

    Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim OD As New OpenFileDialog
        OD.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        If OD.ShowDialog() = DialogResult.OK Then
            Try
                PictureBox1.Load(OD.FileName)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
        Try
            PictureBox1.Image = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.Code39, TextBox1.Text))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim scanner As New MessagingToolkit.Barcode.BarcodeDecoder
        Dim result As MessagingToolkit.Barcode.Result
        Try
            result = scanner.Decode(New Bitmap(PictureBox1.Image))
            MsgBox(result.Text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim SD As New SaveFileDialog
        SD.Filter = "PNG File|*.png"
        If SD.ShowDialog() = DialogResult.OK Then
            Try
                PictureBox1.Image.Save(SD.FileName, Imaging.ImageFormat.Png)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        startwebcam()
        TextBox2.Clear()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        stopwebcam()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            stopwebcam()
            reader = New QRCodeDecoder
            TextBox2.Text = reader.decode(New Data.QRCodeBitmapImage(PictureBox2.Image))
            MsgBox("QR Code is detected")
        Catch ex As Exception
            startwebcam()
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim SD As New SaveFileDialog
        SD.Filter = "PNG|*.Png"
        If SD.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image.Save(SD.FileName, Imaging.ImageFormat.Png)
        End If

    End Sub

    Private Sub TabPage2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage2.Click


    
    End Sub
End Class
