export * from './responses/tipo_identificacion.response';
export interface Response<T>  {
  operation:boolean;
  data:T;
  message?:string;
}
