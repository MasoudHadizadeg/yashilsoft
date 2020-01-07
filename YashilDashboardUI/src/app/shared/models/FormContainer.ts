import {HttpErrorResponse} from '@angular/common/http';

export interface FormContainer {
  /*
   model is data model for put post request
  */
  model: any;
  /*
 fieldErrors is fields that back from server side validating
  */
  fieldErrors: { [key: string]: string[] };
  /*
 loading  until response or error back from server
 */
  isWorking: boolean;
  /*
 help to show correct toast to end user and get http error code
 */
  handleError?: (err: HttpErrorResponse) => boolean;
}
