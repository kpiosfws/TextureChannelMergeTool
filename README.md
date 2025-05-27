本项目由AI生成，只是简单的合并贴图通道到一个png图片里面。
RGBA 通道合成工具（WinForms）
一个基于 C# 和 Windows Forms 的图像工具，支持从多张图片中提取不同的颜色通道（R/G/B/A），并合成为一张新的 PNG 图片。


支持加载最多 4 张图片，分别用于 R/G/B/A 通道

每张图片可选择提取的通道（Red / Green / Blue / Alpha / Grayscale）

使用 LockBits + unsafe 优化图像处理性能

拖拽图片到界面即可加载

实时显示合成进度

支持导出 PNG 图片到本地


自定义图像通道编辑

材质贴图合成（如 Unity / UE 纹理优化）

批量制作 RGBA 通道组合图像


C#

.NET 8 / WinForms

GDI+（System.Drawing）

Visual Studio
