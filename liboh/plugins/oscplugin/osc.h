//
// C++ Interface: osc
//
// Description: 
//
//
// Author: Robert Hamilton <>, (C) 2008
//
// Copyright: See COPYING file that comes with this distribution
//
//

namespace oscplugin {

struct mito_data {
    int user_id;
    int path_id;
    int cell_id;
    float global_x;
    float global_y;
    float global_z;
    float relative_x;
    float relative_y;
};

struct camera_coordinates {
	float camera_x;
	float camera_y;
	float camera_z;
};


typedef struct {
    char *hostname;
    char *port;
    int clientnum;
    float origin[3];
    int pm_flags;
    int weapon;
    int weaponstate;
    int jumppad_ent;
    int damageEvent;
    int damageYaw;
    int damagePitch;
    int damageCount;
    int surfaceFlags;
    int groundEntityNum;
    char *classname;
    char *hostnames[20]; // rkh - added array of client IPs
    /* additional Data points used in q3apd and for future use in q3osc: */
    int velocity[3];
    int viewangles[3];
    int delta_angles[3];
} osc_client_vars;



typedef struct {
    float g_gravity;
    int g_gravity_update;
    int g_speed;
    int g_speed_update;
    int g_homing_speed;
    int g_homing_speed_update;
    int testvar;
} osc_input_vars;


//void sendOSCmessage(int clientno, char *hostname, char *portnumber);
//void sendOSCbundle(ball_coordinates currentClient);
void sendOSCmessage(mito_data data);

//void sendOSCbundle_projectile(osc_projectile_vars currentProjectile);
//void sendOSCmessage_projectile(osc_projectile_vars currentProjectile); //, char *type);

void receiveOSCmessage( void ); // osc listener method

osc_input_vars getOSCmessage( void ); // test data retrieval

void getIPAddress (int index);

void init();	// ini reader
	
}

