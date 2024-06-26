# Normal

Write-Host "Generating normal..."

$normalArgs = @{
    Path = "$PSScriptRoot\ClrDebug"
    NumberAsValueOnSimpleInvocation = $true
    Namespace = "ClrDebug"
    Partial = "CorDebug","CLRMetaHost","CLRMetaHostPolicy","CLRDebugging","MetaDataDispenserEx","CorDebugValue"
    FancyExceptions = $true
    Skip = "*CorDebugManagedCallbackEventArgs","ClassFactory","Dia*Callback","IDiaStackWalkFrame","DiaStackWalkHelper"
    ManualArray = "isosdacinterface.getappdomainlist","ICorDebugCode.GetCode","ITypeInfo.GetNames","ITypeLib.FindName","ICorDebugProcess2.SetUnmanagedBreakpoint","ICorDebugStringValue.GetString"
    MaxPathArray = "ixclrdata*.getfilename"
    MaxLongPathArray = "ISymNGenWriter*.QueryPDBNameExW"
    SkipFolder = "DbgEng"
    NotAbstract = "ICorDebugReferenceValue","ICorDebugObjectValue*","IMetaDataDispenser","IInspectable","IEnumUnknown"

    # Indicates that the string is not null terminated and that we should convert to a string by specifying the specific number of characters to read
    NonNullString = "IMetaDataImport.GetUserString"

    ComPrefix = "IStream","ITypeLib"
    MirrorNamespace = $true
    BaseCallbackTypes = "ICorProfilerCallback*"

    CharArrayHandler = "ClrDebug.Extensions.CreateString"
    EmptyArrayInit = "IXCLRDataFrame.GetArgumentByIndex"
    GeneratedMarshalling = "GENERATED_MARSHALLING"

    SFalseBool = "IDia*"
}

New-ComWrapper @normalArgs

Write-Host "Generating DbgEng..."

# DbgEng

$dbgEngArgs = @{
    Path = "$PSScriptRoot\ClrDebug"
    NumberAsValueOnSimpleInvocation = $true
    Namespace = "ClrDebug.DbgEng"
    Partial = "DebugClient"
    FancyExceptions = $true
    Skip = "*Callback*"
    IncludeFolders = "DebugClient"
    VTable = $true
    DefaultFolder = "DbgEng\DebugClient"
    FancyExceptionHandler = "ThrowDbgEngNotOK"
    CDecl = "IDebugControl*.Output","IDebugControl*.OutputWide","IDebugControl*.ControlledOutput*","IDebugControl*.OutputPrompt*"
    FailedOnlyFancyExceptionHandler = "ThrowDbgEngFailed"
    ManualArray = "idebugcontrol.getstacktrace","idebugcontrol5.getstacktraceex"

    CharArrayHandler = "ClrDebug.Extensions.CreateString"
}

New-ComWrapper @dbgEngArgs

Write-Host "Generating DbgEng (Extra)..."

# DbgEng Model/Services

$dbgEngExtraArgs = @{
    Path = "$PSScriptRoot\ClrDebug"
    NumberAsValueOnSimpleInvocation = $true
    Namespace = "ClrDebug.DbgEng"
    FancyExceptions = $true
    IncludeFolders = "DbgEng"
    SkipFolder = "DebugClient"
    NotAbstract = "IClrDacAndSosProvider"
    DefaultFolder = "DbgEng"
    FancyExceptionHandler = "ThrowDbgEngNotOK"
    FailedOnlyFancyExceptionHandler = "ThrowDbgEngFailed"
    CharArrayHandler = "ClrDebug.Extensions.CreateString"
}

New-ComWrapper @dbgEngExtraArgs