interface IAditionalData {
  [key:string]: string | number
}

export interface InteractionResponse {
  errors?:[];
  status:number;
  aditionalData:IAditionalData;
  operation: boolean;
}


export  interface DatatableMetaResponse
{
    limit:number;
    count:number;
    maxPages:number;
    currentPage:number;
}

export interface DatatableResponse<T>
{
    data:Array<T>;
    meta:DatatableMetaResponse;
}

export interface ResponseApi<T>
{
    data:T;
    meta:DatatableMetaResponse | [];
}
