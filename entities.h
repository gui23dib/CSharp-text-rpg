#ifndef ENTITIES_H
#define ENTITIED_H

#define NAME_STRINGS_MAX_NUM 32

typedef struct {
    int dex; //dexterity
    int str; //strentgh
    int cons; //constitution
    int wis; //wisdowm
    int inte; // intelligence
    int cha; //charisma
} attributes;

typedef struct {
    char name[NAME_STRINGS_MAX_NUM];
    int health_points;
    int exp_points;
    int action_points;
    int level;
    attributes att;
} character;


#endif 
