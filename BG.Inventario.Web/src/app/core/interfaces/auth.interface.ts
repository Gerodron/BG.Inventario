export interface IAuthRequest{
    UserName: string,
    Password: string
}

export interface IAuthResponse{
    userId:    number;
    firstName: string;
    lastName:  string;
    token : string
}

export interface BaseResponseApi {
    statusCode: number;
    success:    boolean;
    message:    string;
    data:       IAuthResponse | null | undefined;
}