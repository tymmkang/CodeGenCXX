##################################################
# Global config
##################################################

set(CONFIG_PROJECT_NAME "CodeGenCXX")
set(CONFIG_SOURCE_DIR "Source")
set(CONFIG_SOURCE_PATH ${CMAKE_SOURCE_DIR}/${CONFIG_SOURCE_DIR})
set(CONFIG_OUTPUT_DIR "Output")
set(CONFIG_OUTPUT_PATH ${CMAKE_SOURCE_DIR}/${CONFIG_OUTPUT_DIR})
set(CONFIG_EXTERNAL_DIR "External")
set(CONFIG_EXTERNAL_PATH ${CMAKE_SOURCE_DIR}/${CONFIG_EXTERNAL_DIR})
set(CONFIG_SUPPORT_PLATFORMS "x64;x86;Win32")
set(CONFIG_PROJECT_CONFIG_TYPES "Debug;Release")

##################################################
# ~Global config
##################################################

##################################################
# Version, Project
##################################################

cmake_minimum_required(VERSION 3.3)
project(${CONFIG_PROJECT_NAME})

##################################################
# ~Version, Project
##################################################

##################################################
# FetchContent setting
##################################################

include(FetchContent)
set(VAR_FETCHCONTENT_BASE_DIR ${FETCHCONTENT_BASE_DIR})
set(VAR_FETCHCONTENT_FULLY_DISCONNECTED ${FETCHCONTENT_FULLY_DISCONNECTED})
set(VAR_FETCHCONTENT_QUIET ${FETCHCONTENT_QUIET})
set(VAR_FETCHCONTENT_UPDATES_DISCONNECTED ${FETCHCONTENT_UPDATES_DISCONNECTED})
unset(FETCHCONTENT_BASE_DIR CACHE)
unset(FETCHCONTENT_FULLY_DISCONNECTED CACHE)
unset(FETCHCONTENT_QUIET CACHE)
unset(FETCHCONTENT_UPDATES_DISCONNECTED CACHE)
set(FETCHCONTENT_BASE_DIR ${VAR_FETCHCONTENT_BASE_DIR})
set(FETCHCONTENT_FULLY_DISCONNECTED ${VAR_FETCHCONTENT_FULLY_DISCONNECTED})
set(FETCHCONTENT_QUIET ${VAR_FETCHCONTENT_QUIET})
set(FETCHCONTENT_UPDATES_DISCONNECTED ${VAR_FETCHCONTENT_UPDATES_DISCONNECTED})

##################################################
# ~FetchContent setting
##################################################

##################################################
# Build platform
##################################################

if("${CMAKE_GENERATOR_PLATFORM}" STREQUAL "")
    set(CMAKE_GENERATOR_PLATFORM "x64") # Treat as x64 if implicit
endif()

if (NOT ${CMAKE_GENERATOR_PLATFORM} IN_LIST CONFIG_SUPPORT_PLATFORMS)
    message(FATAL_ERROR "'${CMAKE_GENERATOR_PLATFORM}' platform is not supported.")
endif()

##################################################
# ~Build platform
##################################################

##################################################
# Build config
##################################################

set(VAR_CONFIG_TYPES ${CMAKE_CONFIGURATION_TYPES})
unset(CMAKE_CONFIGURATION_TYPES CACHE)

set(VAR_VALID_CONFIG_TYPES)
foreach(VAR_CONFIG_TYPE ${VAR_CONFIG_TYPES})
    if (${VAR_CONFIG_TYPE} IN_LIST CONFIG_PROJECT_CONFIG_TYPES)
        list(APPEND VAR_VALID_CONFIG_TYPES ${VAR_CONFIG_TYPE})
        string(TOUPPER ${VAR_CONFIG_TYPE} UPPERCASE_CONFIG_TYPE)
        add_compile_definitions("$<$<CONFIG:${VAR_CONFIG_TYPE}>:${UPPERCASE_CONFIG_TYPE}>")
    endif()
endforeach()

set(CMAKE_CONFIGURATION_TYPES ${VAR_VALID_CONFIG_TYPES})

##################################################
# ~Build config
##################################################

set_property(GLOBAL PROPERTY USE_FOLDERS ON)
add_subdirectory("Source")
