export interface IDynamicParameters {
  [key:string]: string | number
}

export enum ROUTES_APP_NAVIGATION {
  LISTAR_PERSONAS,
  CREAR_PERSONAS,
  LOGIN,
  PANEL_SELECCION
}


export enum NAVIGATION_TYPE {
  BACKOFFICE
}


export const RoutesNavigation:{[key: string]: string} = {
  [ROUTES_APP_NAVIGATION.CREAR_PERSONAS]: 'backoffice/personas/create',
  [ROUTES_APP_NAVIGATION.LISTAR_PERSONAS]: 'backoffice/personas/list',
  [ROUTES_APP_NAVIGATION.PANEL_SELECCION]: 'backoffice',
  [ROUTES_APP_NAVIGATION.LOGIN]: 'auth/login',

}


