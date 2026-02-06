export interface BaseResponseApi<T> {
    statusCode: number;
    success:    boolean;
    message:    string;
    data:       T | null
}