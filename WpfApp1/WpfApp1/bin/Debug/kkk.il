
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern PresentationFramework
{
  .publickeytoken = (31 BF 38 56 AD 36 4E 35 )                         // 1.8V.6N5
  .ver 4:0:0:0
}
.assembly extern System
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern System.Xaml
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern PresentationCore
{
  .publickeytoken = (31 BF 38 56 AD 36 4E 35 )                         // 1.8V.6N5
  .ver 4:0:0:0
}
.assembly WpfApp1
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- 下列自定义特性会自动添加，不要取消注释 -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 07 57 70 66 41 70 70 31 00 00 )             // ...WpfApp1..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 07 57 70 66 41 70 70 31 00 00 )             // ...WpfApp1..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 31 38 00 00 )                            //  2018..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [PresentationFramework]System.Windows.ThemeInfoAttribute::.ctor(valuetype [PresentationFramework]System.Windows.ResourceDictionaryLocation,
                                                                                        valuetype [PresentationFramework]System.Windows.ResourceDictionaryLocation) = ( 01 00 00 00 00 00 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1C 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 36 2E 31 01   // ,Version=v4.6.1.
                                                                                                        00 54 0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73   // .T..FrameworkDis
                                                                                                        70 6C 61 79 4E 61 6D 65 14 2E 4E 45 54 20 46 72   // playName..NET Fr
                                                                                                        61 6D 65 77 6F 72 6B 20 34 2E 36 2E 31 )          // amework 4.6.1
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.mresource public WpfApp1.g.resources
{
  // Offset: 0x00000000 Length: 0x00000621
  // 警告: 创建了托管资源文件 WpfApp1.g.resources
}
.mresource public WpfApp1.Properties.Resources.resources
{
  // Offset: 0x00000628 Length: 0x000000B4
  // 警告: 创建了托管资源文件 WpfApp1.Properties.Resources.resources
}
.module WpfApp1.exe
// MVID: {1804AD6F-496D-4297-AB98-B7F4E9500363}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0002       // WINDOWS_GUI
.corflags 0x00020003    //  ILONLY 32BITPREFERRED
// Image base: 0x07350000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit WpfApp1.App
       extends [PresentationFramework]System.Windows.Application
{
  .method public hidebysig instance void 
          InitializeComponent() cil managed
  {
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                        string) = ( 01 00 16 50 72 65 73 65 6E 74 61 74 69 6F 6E 42   // ...PresentationB
                                                                                                    75 69 6C 64 54 61 73 6B 73 07 34 2E 30 2E 30 2E   // uildTasks.4.0.0.
                                                                                                    30 00 00 )                                        // 0..
    // 代码大小       20 (0x14)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldstr      "MainWindow.xaml"
    IL_0007:  ldc.i4.2
    IL_0008:  newobj     instance void [System]System.Uri::.ctor(string,
                                                                 valuetype [System]System.UriKind)
    IL_000d:  call       instance void [PresentationFramework]System.Windows.Application::set_StartupUri(class [System]System.Uri)
    IL_0012:  nop
    IL_0013:  ret
  } // end of method App::InitializeComponent

  .method public hidebysig static void  Main() cil managed
  {
    .entrypoint
    .custom instance void [mscorlib]System.STAThreadAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                        string) = ( 01 00 16 50 72 65 73 65 6E 74 61 74 69 6F 6E 42   // ...PresentationB
                                                                                                    75 69 6C 64 54 61 73 6B 73 07 34 2E 30 2E 30 2E   // uildTasks.4.0.0.
                                                                                                    30 00 00 )                                        // 0..
    // 代码大小       22 (0x16)
    .maxstack  1
    .locals init ([0] class WpfApp1.App app)
    IL_0000:  nop
    IL_0001:  newobj     instance void WpfApp1.App::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  callvirt   instance void WpfApp1.App::InitializeComponent()
    IL_000d:  nop
    IL_000e:  ldloc.0
    IL_000f:  callvirt   instance int32 [PresentationFramework]System.Windows.Application::Run()
    IL_0014:  pop
    IL_0015:  ret
  } // end of method App::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 代码大小       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [PresentationFramework]System.Windows.Application::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method App::.ctor

} // end of class WpfApp1.App

.class public auto ansi beforefieldinit WpfApp1.MainWindow
       extends [PresentationFramework]System.Windows.Window
       implements [System.Xaml]System.Windows.Markup.IComponentConnector
{
  .field assembly class [PresentationFramework]System.Windows.Controls.TextBox a
  .field assembly class [PresentationFramework]System.Windows.Controls.Button b
  .field private bool _contentLoaded
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 代码大小       40 (0x28)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [PresentationFramework]System.Windows.Window::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldarg.0
    IL_0009:  call       instance void WpfApp1.MainWindow::InitializeComponent()
    IL_000e:  nop
    IL_000f:  ldarg.0
    IL_0010:  ldfld      class [PresentationFramework]System.Windows.Controls.Button WpfApp1.MainWindow::b
    IL_0015:  ldarg.0
    IL_0016:  ldftn      instance void WpfApp1.MainWindow::'<.ctor>b__0_0'(object,
                                                                           class [PresentationCore]System.Windows.RoutedEventArgs)
    IL_001c:  newobj     instance void [PresentationCore]System.Windows.RoutedEventHandler::.ctor(object,
                                                                                                  native int)
    IL_0021:  callvirt   instance void [PresentationFramework]System.Windows.Controls.Primitives.ButtonBase::add_Click(class [PresentationCore]System.Windows.RoutedEventHandler)
    IL_0026:  nop
    IL_0027:  ret
  } // end of method MainWindow::.ctor

  .method public hidebysig newslot virtual final 
          instance void  InitializeComponent() cil managed
  {
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                        string) = ( 01 00 16 50 72 65 73 65 6E 74 61 74 69 6F 6E 42   // ...PresentationB
                                                                                                    75 69 6C 64 54 61 73 6B 73 07 34 2E 30 2E 30 2E   // uildTasks.4.0.0.
                                                                                                    30 00 00 )                                        // 0..
    // 代码大小       42 (0x2a)
    .maxstack  2
    .locals init ([0] class [System]System.Uri resourceLocater,
             [1] bool V_1)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      bool WpfApp1.MainWindow::_contentLoaded
    IL_0007:  stloc.1
    IL_0008:  ldloc.1
    IL_0009:  brfalse.s  IL_000e

    IL_000b:  nop
    IL_000c:  br.s       IL_0029

    IL_000e:  ldarg.0
    IL_000f:  ldc.i4.1
    IL_0010:  stfld      bool WpfApp1.MainWindow::_contentLoaded
    IL_0015:  ldstr      "/WpfApp1;component/mainwindow.xaml"
    IL_001a:  ldc.i4.2
    IL_001b:  newobj     instance void [System]System.Uri::.ctor(string,
                                                                 valuetype [System]System.UriKind)
    IL_0020:  stloc.0
    IL_0021:  ldarg.0
    IL_0022:  ldloc.0
    IL_0023:  call       void [PresentationFramework]System.Windows.Application::LoadComponent(object,
                                                                                               class [System]System.Uri)
    IL_0028:  nop
    IL_0029:  ret
  } // end of method MainWindow::InitializeComponent

  .method private hidebysig newslot virtual final 
          instance void  System.Windows.Markup.IComponentConnector.Connect(int32 connectionId,
                                                                           object target) cil managed
  {
    .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
    .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                        string) = ( 01 00 16 50 72 65 73 65 6E 74 61 74 69 6F 6E 42   // ...PresentationB
                                                                                                    75 69 6C 64 54 61 73 6B 73 07 34 2E 30 2E 30 2E   // uildTasks.4.0.0.
                                                                                                    30 00 00 )                                        // 0..
    .custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = ( 01 00 01 00 00 00 00 00 ) 
    .override [System.Xaml]System.Windows.Markup.IComponentConnector::Connect
    // 代码大小       51 (0x33)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  nop
    IL_0001:  ldarg.1
    IL_0002:  stloc.0
    IL_0003:  ldloc.0
    IL_0004:  ldc.i4.1
    IL_0005:  beq.s      IL_000f

    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ldc.i4.2
    IL_000b:  beq.s      IL_001d

    IL_000d:  br.s       IL_002b

    IL_000f:  ldarg.0
    IL_0010:  ldarg.2
    IL_0011:  castclass  [PresentationFramework]System.Windows.Controls.TextBox
    IL_0016:  stfld      class [PresentationFramework]System.Windows.Controls.TextBox WpfApp1.MainWindow::a
    IL_001b:  br.s       IL_0032

    IL_001d:  ldarg.0
    IL_001e:  ldarg.2
    IL_001f:  castclass  [PresentationFramework]System.Windows.Controls.Button
    IL_0024:  stfld      class [PresentationFramework]System.Windows.Controls.Button WpfApp1.MainWindow::b
    IL_0029:  br.s       IL_0032

    IL_002b:  ldarg.0
    IL_002c:  ldc.i4.1
    IL_002d:  stfld      bool WpfApp1.MainWindow::_contentLoaded
    IL_0032:  ret
  } // end of method MainWindow::System.Windows.Markup.IComponentConnector.Connect

  .method private hidebysig instance void 
          '<.ctor>b__0_0'(object sender,
                          class [PresentationCore]System.Windows.RoutedEventArgs e) cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // 代码大小       19 (0x13)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldfld      class [PresentationFramework]System.Windows.Controls.TextBox WpfApp1.MainWindow::a
    IL_0007:  ldstr      "何润最帅"
    IL_000c:  callvirt   instance void [PresentationFramework]System.Windows.Controls.TextBox::set_Text(string)
    IL_0011:  nop
    IL_0012:  ret
  } // end of method MainWindow::'<.ctor>b__0_0'

} // end of class WpfApp1.MainWindow

.class private auto ansi beforefieldinit WpfApp1.Properties.Resources
       extends [mscorlib]System.Object
{
  .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                      string) = ( 01 00 33 53 79 73 74 65 6D 2E 52 65 73 6F 75 72   // ..3System.Resour
                                                                                                  63 65 73 2E 54 6F 6F 6C 73 2E 53 74 72 6F 6E 67   // ces.Tools.Strong
                                                                                                  6C 79 54 79 70 65 64 52 65 73 6F 75 72 63 65 42   // lyTypedResourceB
                                                                                                  75 69 6C 64 65 72 07 34 2E 30 2E 30 2E 30 00 00 ) // uilder.4.0.0.0..
  .custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private static class [mscorlib]System.Resources.ResourceManager resourceMan
  .field private static class [mscorlib]System.Globalization.CultureInfo resourceCulture
  .method assembly hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 代码大小       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ret
  } // end of method Resources::.ctor

  .method assembly hidebysig specialname static 
          class [mscorlib]System.Resources.ResourceManager 
          get_ResourceManager() cil managed
  {
    // 代码大小       57 (0x39)
    .maxstack  2
    .locals init ([0] bool V_0,
             [1] class [mscorlib]System.Resources.ResourceManager temp,
             [2] class [mscorlib]System.Resources.ResourceManager V_2)
    IL_0000:  nop
    IL_0001:  ldsfld     class [mscorlib]System.Resources.ResourceManager WpfApp1.Properties.Resources::resourceMan
    IL_0006:  ldnull
    IL_0007:  ceq
    IL_0009:  stloc.0
    IL_000a:  ldloc.0
    IL_000b:  brfalse.s  IL_002f

    IL_000d:  nop
    IL_000e:  ldstr      "WpfApp1.Properties.Resources"
    IL_0013:  ldtoken    WpfApp1.Properties.Resources
    IL_0018:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_001d:  callvirt   instance class [mscorlib]System.Reflection.Assembly [mscorlib]System.Type::get_Assembly()
    IL_0022:  newobj     instance void [mscorlib]System.Resources.ResourceManager::.ctor(string,
                                                                                         class [mscorlib]System.Reflection.Assembly)
    IL_0027:  stloc.1
    IL_0028:  ldloc.1
    IL_0029:  stsfld     class [mscorlib]System.Resources.ResourceManager WpfApp1.Properties.Resources::resourceMan
    IL_002e:  nop
    IL_002f:  ldsfld     class [mscorlib]System.Resources.ResourceManager WpfApp1.Properties.Resources::resourceMan
    IL_0034:  stloc.2
    IL_0035:  br.s       IL_0037

    IL_0037:  ldloc.2
    IL_0038:  ret
  } // end of method Resources::get_ResourceManager

  .method assembly hidebysig specialname static 
          class [mscorlib]System.Globalization.CultureInfo 
          get_Culture() cil managed
  {
    // 代码大小       11 (0xb)
    .maxstack  1
    .locals init ([0] class [mscorlib]System.Globalization.CultureInfo V_0)
    IL_0000:  nop
    IL_0001:  ldsfld     class [mscorlib]System.Globalization.CultureInfo WpfApp1.Properties.Resources::resourceCulture
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Resources::get_Culture

  .method assembly hidebysig specialname static 
          void  set_Culture(class [mscorlib]System.Globalization.CultureInfo 'value') cil managed
  {
    // 代码大小       8 (0x8)
    .maxstack  8
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  stsfld     class [mscorlib]System.Globalization.CultureInfo WpfApp1.Properties.Resources::resourceCulture
    IL_0007:  ret
  } // end of method Resources::set_Culture

  .property class [mscorlib]System.Resources.ResourceManager
          ResourceManager()
  {
    .custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = ( 01 00 02 00 00 00 00 00 ) 
    .get class [mscorlib]System.Resources.ResourceManager WpfApp1.Properties.Resources::get_ResourceManager()
  } // end of property Resources::ResourceManager
  .property class [mscorlib]System.Globalization.CultureInfo
          Culture()
  {
    .custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = ( 01 00 02 00 00 00 00 00 ) 
    .get class [mscorlib]System.Globalization.CultureInfo WpfApp1.Properties.Resources::get_Culture()
    .set void WpfApp1.Properties.Resources::set_Culture(class [mscorlib]System.Globalization.CultureInfo)
  } // end of property Resources::Culture
} // end of class WpfApp1.Properties.Resources

.class private auto ansi sealed beforefieldinit WpfApp1.Properties.Settings
       extends [System]System.Configuration.ApplicationSettingsBase
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string,
                                                                                      string) = ( 01 00 4B 4D 69 63 72 6F 73 6F 66 74 2E 56 69 73   // ..KMicrosoft.Vis
                                                                                                  75 61 6C 53 74 75 64 69 6F 2E 45 64 69 74 6F 72   // ualStudio.Editor
                                                                                                  73 2E 53 65 74 74 69 6E 67 73 44 65 73 69 67 6E   // s.SettingsDesign
                                                                                                  65 72 2E 53 65 74 74 69 6E 67 73 53 69 6E 67 6C   // er.SettingsSingl
                                                                                                  65 46 69 6C 65 47 65 6E 65 72 61 74 6F 72 08 31   // eFileGenerator.1
                                                                                                  31 2E 30 2E 30 2E 30 00 00 )                      // 1.0.0.0..
  .field private static class WpfApp1.Properties.Settings defaultInstance
  .method public hidebysig specialname static 
          class WpfApp1.Properties.Settings 
          get_Default() cil managed
  {
    // 代码大小       11 (0xb)
    .maxstack  1
    .locals init ([0] class WpfApp1.Properties.Settings V_0)
    IL_0000:  nop
    IL_0001:  ldsfld     class WpfApp1.Properties.Settings WpfApp1.Properties.Settings::defaultInstance
    IL_0006:  stloc.0
    IL_0007:  br.s       IL_0009

    IL_0009:  ldloc.0
    IL_000a:  ret
  } // end of method Settings::get_Default

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 代码大小       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [System]System.Configuration.ApplicationSettingsBase::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Settings::.ctor

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // 代码大小       21 (0x15)
    .maxstack  8
    IL_0000:  newobj     instance void WpfApp1.Properties.Settings::.ctor()
    IL_0005:  call       class [System]System.Configuration.SettingsBase [System]System.Configuration.SettingsBase::Synchronized(class [System]System.Configuration.SettingsBase)
    IL_000a:  castclass  WpfApp1.Properties.Settings
    IL_000f:  stsfld     class WpfApp1.Properties.Settings WpfApp1.Properties.Settings::defaultInstance
    IL_0014:  ret
  } // end of method Settings::.cctor

  .property class WpfApp1.Properties.Settings
          Default()
  {
    .get class WpfApp1.Properties.Settings WpfApp1.Properties.Settings::get_Default()
  } // end of property Settings::Default
} // end of class WpfApp1.Properties.Settings


// =============================================================

// *********** 反汇编完成 ***********************
// 警告: 创建了 Win32 资源文件 C:\Users\圣三一\Desktop\WpfApp1\WpfApp1\bin\Debug\kkk.res
