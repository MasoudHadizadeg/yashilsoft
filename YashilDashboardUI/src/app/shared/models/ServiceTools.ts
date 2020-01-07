import {environment} from '../../../environments/environment';

export class ServiceTools {
  static api(relative: string) {
    return environment.serverRootUrl + relative;
  }
}
