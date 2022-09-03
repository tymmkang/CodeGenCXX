# Sample

file(GLOB_RECURSE 
    VAR_SOURCES
    ${CMAKE_CURRENT_LIST_DIR}/*.h
    ${CMAKE_CURRENT_LIST_DIR}/*.cpp
    ${CMAKE_CURRENT_LIST_DIR}/*.hpp)

source_group(
    TREE ${CMAKE_CURRENT_LIST_DIR} 
    FILES ${VAR_SOURCES})

add_executable("Sample" ${VAR_SOURCES})
set_target_properties("Sample" PROPERTIES
    RUNTIME_OUTPUT_DIRECTORY    ${CONFIG_OUTPUT_PATH}/$<CONFIG>
    LINKER_LANGUAGE             CXX
    CXX_STANDARD                20)
set_property(DIRECTORY ${CMAKE_CURRENT_SOURCE_DIR} 
    PROPERTY VS_STARTUP_PROJECT "Sample")
