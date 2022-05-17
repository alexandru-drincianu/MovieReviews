import { AUTH, LOGOUT } from "../constants/actionTypes";

const authReducer = (state = {authData: null}, action) => {
    switch(action.type){
        case AUTH:
            localStorage.setItem('profile',action?.data);
            //localStorage.setItem('tk', action?.data.tk);
            //localStorage.setItem('id', action?.data.id);
            //localStorage.setItem('id', action?.data.roles);
            return {...state, authData: action.data, errors: null};
        case LOGOUT:
            localStorage.clear();
            return {...state, authData: null, errors: null};
        default:
            return state;
    }
}

export default authReducer;