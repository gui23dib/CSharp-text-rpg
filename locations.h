#ifndef LOCATIONS_H
#define LOCATIONS_H

#include "entities.h"

typedef struct {
    char name[NAME_STRINGS_MAX_NUM];
} location;

typedef struct {
    char name[NAME_STRINGS_MAX_NUM];
    location location;
    character character;
} encounter;

#endif 
