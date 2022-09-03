# Get all subdirectories and 'add_subdirectory' if subdirectory contains CMakeLists.txt

file(GLOB VAR_CONTENTS RELATIVE 
    ${CMAKE_CURRENT_LIST_DIR} 
    ${CMAKE_CURRENT_LIST_DIR}/*)

set(VAR_VALID_SUBDIRECTORIES)
foreach (VAR_CONTENT ${VAR_CONTENTS})
    if (IS_DIRECTORY ${CMAKE_CURRENT_LIST_DIR}/${CONTENT} AND 
        EXISTS ${CMAKE_CURRENT_LIST_DIR}/${VAR_CONTENT}/CMakeLists.txt)

        list(APPEND VAR_VALID_SUBDIRECTORIES ${VAR_CONTENT})
    endif ()
endforeach ()

foreach(VAR_VALID_SUBDIRECTORIE ${VAR_VALID_SUBDIRECTORIES})
    add_subdirectory("${VAR_VALID_SUBDIRECTORIE}")
endforeach()
