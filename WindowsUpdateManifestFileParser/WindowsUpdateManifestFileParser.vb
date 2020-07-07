Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
''' <summary>
''' 用于解析 Windows Update 包描述文件的工具。
''' </summary>
''' <remarks></remarks>
Public Class WindowsUpdateManifestFileParser
    ''' <summary>
    ''' 描述 Windows Update 包的识别信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="assemblyIdentity", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class AssemblyIdentity
        ''' <summary>
        ''' 指示包名。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="name")> Public Name As String
        ''' <summary>
        ''' 指示包的版本。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="version")> Public Version As String
        ''' <summary>
        ''' 指示包的语言。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="language")> Public Language As String
        ''' <summary>
        ''' 指示包的目标处理器架构。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="processorArchitecture")> Public ProcessorArchitecture As String
        ''' <summary>
        ''' 指示包的公钥令牌。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="publicKeyToken")> Public PublicKeyToken As String
        ''' <summary>
        ''' 指示包的构造类型。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="buildType")> Public BuildType As String
        ''' <summary>
        ''' 指示包的版本作用域。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="versionScope")> Public VersionScope As String
    End Class
    ''' <summary>
    ''' 描述以移动设备为目标的包的移动设备相关组件信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="phoneInformation", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class PhoneInformation
        ''' <summary>
        ''' 指示包的发行方式类型。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="phoneRelease")> Public PhoneRelease As String
        ''' <summary>
        ''' 指示包所隶属的所有者的类型。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="phoneOwnerType")> Public PhoneOwnerType As String
        ''' <summary>
        ''' 指示包所隶属的所有者。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="phoneOwner")> Public PhoneOwner As String
        ''' <summary>
        ''' 指示包所提供的组件名称。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="phoneComponent")> Public PhoneComponent As String
        ''' <summary>
        ''' 指示包所提供的子组件名称。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="phoneSubComponent")> Public PhoneSubComponent As String
        ''' <summary>
        ''' 指示包的组类型。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="phoneGroupingKey")> Public PhoneGroupingKey As String
    End Class
    ''' <summary>
    ''' 描述自定义信息中的文件信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="file", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class File
        ''' <summary>
        ''' 指示文件的复制目标路径。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="name")> Public Name As String
        ''' <summary>
        ''' 指示文件的尺寸，单位是字节。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="size")> Public Size As String
        ''' <summary>
        ''' 指示文件是否已暂存。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="staged")> Public Staged As String
        ''' <summary>
        ''' 指示文件是否已压缩。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="compressed")> Public Compressed As String
        ''' <summary>
        ''' 指示文件的来源包。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="sourcePackage")> Public SourcePackage As String
        ''' <summary>
        ''' 指示文件是否使用嵌入式数字签名。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="embeddedSign")> Public EmbeddedSign As String
        ''' <summary>
        ''' 指示文件在包中的路径。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="cabpath")> Public Cabpath As String
    End Class
    ''' <summary>
    ''' 描述包的自定义信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="customInformation", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class CustomInformation
        ''' <summary>
        ''' 描述以移动设备为目标的包的移动设备相关组件信息。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="phoneInformation", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public PhoneInformation As PhoneInformation
        ''' <summary>
        ''' 包中所包含的文件的清单。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="file", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public File As New List(Of File)
    End Class
    ''' <summary>
    ''' 描述包的组件信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="component", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class Component
        ''' <summary>
        ''' 提供包的识别信息。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="assemblyIdentity", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public AssemblyIdentity As AssemblyIdentity
    End Class
    ''' <summary>
    ''' 描述用于提供给 Windows Update 的更新包信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="update", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class Update
        ''' <summary>
        ''' 提供包的组件信息。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="component", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Component As Component
        ''' <summary>
        ''' 指示包的名称。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="name")> Public Name As String
    End Class
    ''' <summary>
    ''' 描述包的内容。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="package", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class Package
        ''' <summary>
        ''' 提供包的自定义信息。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="customInformation", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public CustomInformation As CustomInformation
        ''' <summary>
        ''' 提供用于提供给 Windows Update 的更新包信息。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="update", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Update As Update
        ''' <summary>
        ''' 描述包的识别信息。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="identifier")> Public Identifier As String
        ''' <summary>
        ''' 描述包的发布类型。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="releaseType")> Public ReleaseType As String
        ''' <summary>
        ''' 指示此包应用后是否需要重新启动设备。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="restart")> Public Restart As String
        ''' <summary>
        ''' 指示包的目标分区。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="targetPartition")> Public TargetPartition As String
        ''' <summary>
        ''' 指示包的目标分区的二进制位图。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="binaryPartition")> Public BinaryPartition As String
    End Class
    ''' <summary>
    ''' 提供写入注册表的项值对的集合。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="registryKey", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class RegistryKey
        ''' <summary>
        ''' 指示需要写入注册表的项值对。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="registryValue", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public RegistryValues As New List(Of RegistryValue)
        ''' <summary>
        ''' 指示需要写入的注册表键。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="keyName", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public KeyName As String
        ''' <summary>
        ''' 指示安全描述符。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="securityDescriptor", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public SecurityDescriptor As SecurityDescriptor
    End Class
    ''' <summary>
    ''' 提供安全描述符信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="securityDescriptor", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class SecurityDescriptor
        ''' <summary>
        ''' 指示安全描述符的名称。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="name", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Name As String
    End Class
    ''' <summary>
    ''' 提供需要写入注册表的项值对的信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="registryValue", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class RegistryValue
        ''' <summary>
        ''' 指示注册表项的名称。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="name")> Public Name As String
        ''' <summary>
        ''' 指示注册表项的值。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="value")> Public Value As String
        ''' <summary>
        ''' 指示注册表项的类型。
        ''' </summary>
        ''' <remarks>这个类型可能是通过"REG_"开头的常量表示的，也可能是通过十六进制值表示的，对于通过十六进制值表示的类型，在创建 REG 文件时只需将该十六进制值作为"hex()"类型指示符的括号中的内容即可。</remarks>
        <XmlAttribute(AttributeName:="valueType")> Public ValueType As String
        ''' <summary>
        ''' 指示注册表项是否可变。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="mutable")> Public Mutable As String
        ''' <summary>
        ''' 指示需要进行的操作。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="operationHint")> Public OperationHint As String 'e.g: replace
    End Class
    ''' <summary>
    ''' 描述 Windows Update 包程序集的信息。
    ''' </summary>
    ''' <remarks></remarks>
    <XmlRoot(ElementName:="assembly", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Class Assembly
        ''' <summary>
        ''' XML 命名空间。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="xmlns")> Public XmlNS As String
        ''' <summary>
        ''' 指示包的识别信息。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="assemblyIdentity", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public AssemblyIdentity As AssemblyIdentity
        ''' <summary>
        ''' 指示需要写入注册表的键、项和值。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlArray(ElementName:="registryKeys", Namespace:="urn:schemas-microsoft-com:asm.v3")> <XmlArrayItem(ElementName:="registryKey")> Public RegistryKeys As New List(Of RegistryKey)
        ''' <summary>
        ''' 指示包的内容。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlElement(ElementName:="package", Namespace:="urn:schemas-microsoft-com:asm.v3")> Public Package As Package
        ''' <summary>
        ''' 指示包描述文件的版本。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="manifestVersion")> Public ManifestVersion As String
        ''' <summary>
        ''' 指示包的显示名称。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="displayName")> Public DisplayName As String
        ''' <summary>
        ''' 指示包的发行公司。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="company")> Public Company As String
        ''' <summary>
        ''' 指示包的版权信息。
        ''' </summary>
        ''' <remarks></remarks>
        <XmlAttribute(AttributeName:="copyright")> Public Copyright As String
        'TODO: trustInfo
    End Class

End Class
