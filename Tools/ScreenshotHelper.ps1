Add-Type -AssemblyName System.Drawing
Add-Type -AssemblyName System.Windows.Forms

function Render-ConsoleWindow {
    param (
        [string]$Title = "Console Window",
        [string[]]$Lines = @(),
        [string]$OutputPath = "console.png",
        [int]$Width = 740,
        [int]$Height = 0,
        [string]$FontName = "Consolas",
        [float]$FontSize = 11.0,
        [System.Drawing.Color]$BgColor = [System.Drawing.Color]::FromArgb(12, 12, 12),
        [System.Drawing.Color]$FgColor = [System.Drawing.Color]::FromArgb(204, 204, 204)
    )

    $lineHeight = 22
    $neededHeight = 32 + 24 + ($Lines.Count * $lineHeight)
    if ($Height -le 0 -or $Height -lt $neededHeight) {
        $Height = $neededHeight
    }

    $bmp = New-Object System.Drawing.Bitmap $Width, $Height
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.TextRenderingHint = [System.Drawing.Text.TextRenderingHint]::ClearTypeGridFit
    $g.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::HighQuality

    # Background
    $bgBrush = New-Object System.Drawing.SolidBrush $BgColor
    $g.FillRectangle($bgBrush, 0, 0, $Width, $Height)

    # Titlebar (Windows 10/11 classic style)
    $titleHeight = 32
    $titleBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(31, 31, 31))
    $g.FillRectangle($titleBrush, 0, 0, $Width, $titleHeight)

    # Title text
    $titleFont = New-Object System.Drawing.Font "Segoe UI", 9.5
    $titleTextBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(220, 220, 220))
    $g.DrawString($Title, $titleFont, $titleTextBrush, 12, 7)

    # Window controls
    $btnPen = New-Object System.Drawing.Pen ([System.Drawing.Color]::FromArgb(160, 160, 160)), 1
    # Minimize
    $g.DrawLine($btnPen, ($Width - 110), 18, ($Width - 100), 18)
    # Maximize
    $g.DrawRectangle($btnPen, ($Width - 75), 11, 10, 10)
    # Close
    $g.DrawLine($btnPen, ($Width - 40), 11, ($Width - 30), 21)
    $g.DrawLine($btnPen, ($Width - 30), 11, ($Width - 40), 21)

    # Border
    $borderPen = New-Object System.Drawing.Pen ([System.Drawing.Color]::FromArgb(50, 50, 50)), 1
    $g.DrawRectangle($borderPen, 0, 0, ($Width - 1), ($Height - 1))

    # Console Body text
    $font = New-Object System.Drawing.Font $FontName, $FontSize
    $textBrush = New-Object System.Drawing.SolidBrush $FgColor

    $lineHeight = [Math]::Round($font.GetHeight($g) + 4)
    $y = $titleHeight + 12
    $x = 14

    foreach ($line in $Lines) {
        $g.DrawString($line, $font, $textBrush, $x, $y)
        $y += $lineHeight
    }

    $bmp.Save($OutputPath, [System.Drawing.Imaging.ImageFormat]::Png)
    $g.Dispose()
    $bmp.Dispose()
}

function Render-TextEditorWindow {
    param (
        [string]$FileName = "input.txt",
        [string[]]$Lines = @(),
        [string]$OutputPath = "editor.png",
        [int]$Width = 640,
        [int]$Height = 360
    )

    $bmp = New-Object System.Drawing.Bitmap $Width, $Height
    $g = [System.Drawing.Graphics]::FromImage($bmp)
    $g.TextRenderingHint = [System.Drawing.Text.TextRenderingHint]::ClearTypeGridFit

    # Window background
    $bgBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(255, 255, 255))
    $g.FillRectangle($bgBrush, 0, 0, $Width, $Height)

    # Titlebar
    $titleHeight = 30
    $titleBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(235, 235, 235))
    $g.FillRectangle($titleBrush, 0, 0, $Width, $titleHeight)

    $titleFont = New-Object System.Drawing.Font "Segoe UI", 9.0
    $titleTextBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(40, 40, 40))
    $g.DrawString("AkelPad - [$FileName]", $titleFont, $titleTextBrush, 10, 6)

    # Tab bar
    $tabHeight = 26
    $tabBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(245, 245, 245))
    $g.FillRectangle($tabBrush, 0, $titleHeight, $Width, $tabHeight)
    $tabActiveBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(255, 255, 255))
    $g.FillRectangle($tabActiveBrush, 10, $titleHeight + 2, 110, $tabHeight - 2)
    $g.DrawString($FileName, $titleFont, $titleTextBrush, 22, $titleHeight + 5)

    # Line number gutter
    $gutterWidth = 46
    $gutterBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(240, 240, 240))
    $g.FillRectangle($gutterBrush, 0, ($titleHeight + $tabHeight), $gutterWidth, ($Height - $titleHeight - $tabHeight - 24))
    $gutterLinePen = New-Object System.Drawing.Pen ([System.Drawing.Color]::FromArgb(215, 215, 215)), 1
    $g.DrawLine($gutterLinePen, $gutterWidth, ($titleHeight + $tabHeight), $gutterWidth, ($Height - 24))

    # Editor text
    $editorFont = New-Object System.Drawing.Font "Consolas", 11.0
    $gutterFont = New-Object System.Drawing.Font "Consolas", 10.0
    $gutterTextBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(140, 140, 140))
    $textBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(20, 20, 20))

    $lineHeight = 22
    $y = $titleHeight + $tabHeight + 8

    for ($i = 0; $i -lt $Lines.Count; $i++) {
        $lineNum = ($i + 1).ToString()
        $g.DrawString($lineNum, $gutterFont, $gutterTextBrush, 12, $y)
        $g.DrawString($Lines[$i], $editorFont, $textBrush, ($gutterWidth + 12), $y)
        $y += $lineHeight
    }

    # Status bar
    $statusY = $Height - 24
    $statusBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(242, 242, 242))
    $g.FillRectangle($statusBrush, 0, $statusY, $Width, 24)
    $statusFont = New-Object System.Drawing.Font "Segoe UI", 8.5
    $statusBrushText = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(100, 100, 100))
    $g.DrawString("Ins   Win 65001 (UTF-8) *BOM", $statusFont, $statusBrushText, 10, $statusY + 4)

    # Window border
    $borderPen = New-Object System.Drawing.Pen ([System.Drawing.Color]::FromArgb(180, 180, 180)), 1
    $g.DrawRectangle($borderPen, 0, 0, ($Width - 1), ($Height - 1))

    $bmp.Save($OutputPath, [System.Drawing.Imaging.ImageFormat]::Png)
    $g.Dispose()
    $bmp.Dispose()
}
