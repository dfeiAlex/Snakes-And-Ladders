Public Class Game
    Dim RNG = New Random()
    Dim dieFaces = New List(Of Image) From {
        My.Resources.die1,
        My.Resources.die2,
        My.Resources.die3,
        My.Resources.die4,
        My.Resources.die5,
        My.Resources.die6
    }

    'Counters for player 1 and 2
    Dim intCount1 As Integer = 1
    Dim intCount2 As Integer = 1

    Public Function rollDie() As Integer
        Return RNG.Next(1, 7) 'Return a number from 1 to 6
    End Function

    Public Sub setDiePic(dieNumber As Integer, picBox As PictureBox)
        picBox.Image = dieFaces(dieNumber - 1)
    End Sub

    'Public Sub movePlayer()
End Class