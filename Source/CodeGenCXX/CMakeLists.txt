# CodeGenCXX

# Windows-Only
if ("${CMAKE_HOST_SYSTEM_NAME}" STREQUAL "Windows")

    set(VAR_CSPROJ_PLATFORM)
    if ("${CMAKE_GENERATOR_PLATFORM}" STREQUAL "x64")
        set(VAR_CSPROJ_PLATFORM "x64")
    elseif ()
        set(VAR_CSPROJ_PLATFORM "x86")
    endif ()

    include_external_msproject("CodeGenCXX" 
        ${CMAKE_CURRENT_LIST_DIR}/CodeGenCXX.csproj 
        PLATFORM "${VAR_CSPROJ_PLATFORM}")
endif ()
