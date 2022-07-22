﻿namespace ClrDebug.DbgEng
{
    public enum DEBUG_DATA : uint
    {
        // Indices for ReadProcessorSystemData.
        KPCR_OFFSET = 0,
        KPRCB_OFFSET = 1,
        KTHREAD_OFFSET = 2,
        BASE_TRANSLATION_VIRTUAL_OFFSET = 3,
        PROCESSOR_IDENTIFICATION = 4,
        PROCESSOR_SPEED = 5,

        // Indices for ReadDebuggerData interface
        KernBase = 24,
        BreakpointWithStatusAddr = 32,
        SavedContextAddr = 40,
        KiCallUserModeAddr = 56,
        KeUserCallbackDispatcherAddr = 64,
        PsLoadedModuleListAddr = 72,
        PsActiveProcessHeadAddr = 80,
        PspCidTableAddr = 88,
        ExpSystemResourcesListAddr = 96,
        ExpPagedPoolDescriptorAddr = 104,
        ExpNumberOfPagedPoolsAddr = 112,
        KeTimeIncrementAddr = 120,
        KeBugCheckCallbackListHeadAddr = 128,
        KiBugcheckDataAddr = 136,
        IopErrorLogListHeadAddr = 144,
        ObpRootDirectoryObjectAddr = 152,
        ObpTypeObjectTypeAddr = 160,
        MmSystemCacheStartAddr = 168,
        MmSystemCacheEndAddr = 176,
        MmSystemCacheWsAddr = 184,
        MmPfnDatabaseAddr = 192,
        MmSystemPtesStartAddr = 200,
        MmSystemPtesEndAddr = 208,
        MmSubsectionBaseAddr = 216,
        MmNumberOfPagingFilesAddr = 224,
        MmLowestPhysicalPageAddr = 232,
        MmHighestPhysicalPageAddr = 240,
        MmNumberOfPhysicalPagesAddr = 248,
        MmMaximumNonPagedPoolInBytesAddr = 256,
        MmNonPagedSystemStartAddr = 264,
        MmNonPagedPoolStartAddr = 272,
        MmNonPagedPoolEndAddr = 280,
        MmPagedPoolStartAddr = 288,
        MmPagedPoolEndAddr = 296,
        MmPagedPoolInformationAddr = 304,
        MmPageSize = 312,
        MmSizeOfPagedPoolInBytesAddr = 320,
        MmTotalCommitLimitAddr = 328,
        MmTotalCommittedPagesAddr = 336,
        MmSharedCommitAddr = 344,
        MmDriverCommitAddr = 352,
        MmProcessCommitAddr = 360,
        MmPagedPoolCommitAddr = 368,
        MmExtendedCommitAddr = 376,
        MmZeroedPageListHeadAddr = 384,
        MmFreePageListHeadAddr = 392,
        MmStandbyPageListHeadAddr = 400,
        MmModifiedPageListHeadAddr = 408,
        MmModifiedNoWritePageListHeadAddr = 416,
        MmAvailablePagesAddr = 424,
        MmResidentAvailablePagesAddr = 432,
        PoolTrackTableAddr = 440,
        NonPagedPoolDescriptorAddr = 448,
        MmHighestUserAddressAddr = 456,
        MmSystemRangeStartAddr = 464,
        MmUserProbeAddressAddr = 472,
        KdPrintCircularBufferAddr = 480,
        KdPrintCircularBufferEndAddr = 488,
        KdPrintWritePointerAddr = 496,
        KdPrintRolloverCountAddr = 504,
        MmLoadedUserImageListAddr = 512,
        NtBuildLabAddr = 520,
        KiNormalSystemCall = 528,
        KiProcessorBlockAddr = 536,
        MmUnloadedDriversAddr = 544,
        MmLastUnloadedDriverAddr = 552,
        MmTriageActionTakenAddr = 560,
        MmSpecialPoolTagAddr = 568,
        KernelVerifierAddr = 576,
        MmVerifierDataAddr = 584,
        MmAllocatedNonPagedPoolAddr = 592,
        MmPeakCommitmentAddr = 600,
        MmTotalCommitLimitMaximumAddr = 608,
        CmNtCSDVersionAddr = 616,
        MmPhysicalMemoryBlockAddr = 624,
        MmSessionBase = 632,
        MmSessionSize = 640,
        MmSystemParentTablePage = 648,
        MmVirtualTranslationBase = 656,
        OffsetKThreadNextProcessor = 664,
        OffsetKThreadTeb = 666,
        OffsetKThreadKernelStack = 668,
        OffsetKThreadInitialStack = 670,
        OffsetKThreadApcProcess = 672,
        OffsetKThreadState = 674,
        OffsetKThreadBStore = 676,
        OffsetKThreadBStoreLimit = 678,
        SizeEProcess = 680,
        OffsetEprocessPeb = 682,
        OffsetEprocessParentCID = 684,
        OffsetEprocessDirectoryTableBase = 686,
        SizePrcb = 688,
        OffsetPrcbDpcRoutine = 690,
        OffsetPrcbCurrentThread = 692,
        OffsetPrcbMhz = 694,
        OffsetPrcbCpuType = 696,
        OffsetPrcbVendorString = 698,
        OffsetPrcbProcessorState = 700,
        OffsetPrcbNumber = 702,
        SizeEThread = 704,
        KdPrintCircularBufferPtrAddr = 712,
        KdPrintBufferSizeAddr = 720,
        MmBadPagesDetected = 800,
        EtwpDebuggerData = 816,

        PaeEnabled = 100000,
        SharedUserData = 100008,
        ProductType = 100016,
        SuiteMask = 100024,
        DumpWriterStatus = 100032,
        DumpFormatVersion = 100040,
        DumpWriterVersion = 100048,
        DumpPowerState = 100056,
        DumpMmStorage = 100064,
        DumpAttributes = 100072,
    }
}
