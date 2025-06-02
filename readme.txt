当前版本控制：
unity版本号：6000.0.28f1
templates：ARmobile
platforms：Android Build Support

安装AR相关SDK：
打开 Unity 编辑器，选择 “Window” -> “Package Manager”。
在 Package Manager 窗口中，点击左上角的 “+” 号，选择 “Add package from git URL”。
输入 com.unity.xr.arfoundation 并点击 “Add”，Unity 会自动下载并安装 AR Foundation。

同样在 Package Manager 中，点击 “+” 号，选择 “Add package from git URL”。
输入 com.unity.xr.arcore 并点击 “Add”，完成安装。

测试AR功能：
创建一个新的 AR 场景：在 Hierarchy 窗口中，右键点击空白处，选择 “XR” -> “AR Session” 和 “XR” -> “AR Session Origin”。
添加 AR 相关的 GameObject，如 AR Plane Manager、AR Raycast Manager 等。
编写简单的 AR 脚本，例如在检测到平面时生成一个 Cube。
点击 “Build and Run” 按钮，将项目部署到安卓手机上进行测试。
通过以上步骤，你就可以完成 Unity AR 项目所需的环境搭建，并将项目部署到安卓手机上。

 Unity 项目中配置 Vuforia SDK：https://developer.vuforia.com/home

 