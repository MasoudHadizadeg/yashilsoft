import * as moment from 'jalali-moment';

export class DateHelper {
    public datePickerConfig = {
        format: 'jYYYY/jMM/jDD',
        dir: 'rtl',
        locale: moment.locale('fa')
    };

    constructor() {
    }

    public convertDateToInt(p: moment.Moment) {
        return p.locale('fa').format('YYYYMMDD');
    }

    public convertIntDateToString(value: number): any {
        if (value) {
            return value.toString().substring(0, 4) + '/' + value.toString().substring(4, 6) + '/' + value.toString().substring(6, 8);
        }
        return '';
    }
}
