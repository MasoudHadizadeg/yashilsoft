import {Injectable} from '@angular/core';

interface Resources {
    name: string;
    src: string;
}

export const ScriptStore: Resources[] = [
    {name: 'report', src: 'assets/stimulsoft/scripts/stimulsoft.reports.js'},
    {name: 'designer', src: 'assets/stimulsoft/scripts/stimulsoft.designer.js'},
    {name: 'viewer', src: 'assets/stimulsoft/scripts/stimulsoft.viewer.js'},
    {name: 'map', src: 'assets/stimulsoft/scripts/stimulsoft.reports.maps.js'}
];
export const CssStore: Resources[] = [
    {name: 'designer_whiteblue', src: 'assets/stimulsoft/css/stimulsoft.designer.office2013.whiteblue.css'},
    {name: 'viewer_whiteblue', src: 'assets/stimulsoft/css/stimulsoft.viewer.office2013.whiteblue.css'},
    {name: 'viewer_lightgraygreen', src: 'assets/stimulsoft/css/stimulsoft.designer.office2013.lightgraygreen.css'},
    {name: 'viewer_verydarkgraygreen', src: 'assets/stimulsoft/css/stimulsoft.viewer.office2013.whiteblue.css'},

];
declare var document: any;

@Injectable()
export class DynamicScriptLoaderService {

    private scripts: any = {};
    private cssStyles: any = {};

    constructor() {
        ScriptStore.forEach((script: any) => {
            this.scripts[script.name] = {
                loaded: false,
                src: script.src
            };
        });

        CssStore.forEach((cssStyle: any) => {
            this.cssStyles[cssStyle.name] = {
                loaded: false,
                src: cssStyle.src
            };
        });
    }

    load(scripts: string[], cssStyles: string[]) {
        const loadScriptPromise = name =>
            this.loadScript(name).then(() => {
            });
        const loadCssPromise = name =>
            this.loadCss(name).then(() => {
            });
        cssStyles.reduce((p, x) =>
                p.then(_ => loadCssPromise(x)),
            Promise.resolve()
        ).then(() => {
        });
        return scripts.reduce(
            (p, x) =>
                p.then(_ => loadScriptPromise(x)),
            Promise.resolve()
        );
    }

    loadScript(name: string) {
        return new Promise((resolve, reject) => {
            if (!this.scripts[name].loaded) {
                // load script
                const script = document.createElement('script');
                script.type = 'text/javascript';
                script.src = this.scripts[name].src;
                if (script.readyState) {  // IE
                    script.onreadystatechange = () => {
                        if (script.readyState === 'loaded' || script.readyState === 'complete') {
                            script.onreadystatechange = null;
                            this.scripts[name].loaded = true;
                            resolve({script: name, loaded: true, status: 'Loaded'});
                        }
                    };
                } else {  // Others
                    script.onload = () => {
                        this.scripts[name].loaded = true;
                        resolve({script: name, loaded: true, status: 'Loaded'});
                    };
                }
                script.onerror = (error: any) => resolve({script: name, loaded: false, status: 'Loaded'});
                document.getElementsByTagName('head')[0].appendChild(script);
            } else {
                resolve({script: name, loaded: true, status: 'Already Loaded'});
            }
        });
    }

    loadCss(name: string) {
        return new Promise((resolve, reject) => {
            if (!this.cssStyles[name].loaded) {
                // load script
                const cssElement = document.createElement('link');
                cssElement.rel = 'stylesheet';
                cssElement.href = this.cssStyles[name].src;
                if (cssElement.readyState) {  // IE
                    cssElement.onreadystatechange = () => {
                        if (cssElement.readyState === 'loaded' || cssElement.readyState === 'complete') {
                            cssElement.onreadystatechange = null;
                            this.cssStyles[name].loaded = true;
                            resolve({script: name, loaded: true, status: 'Loaded'});
                        }
                    };
                } else {  // Others
                    cssElement.onload = () => {
                        this.cssStyles[name].loaded = true;
                        resolve({script: name, loaded: true, status: 'Loaded'});
                    };
                }
                cssElement.onerror = (error: any) => resolve({script: name, loaded: false, status: 'Loaded'});
                document.getElementsByTagName('head')[0].appendChild(cssElement);
            } else {
                resolve({script: name, loaded: true, status: 'Already Loaded'});
            }
        });
    }

}
