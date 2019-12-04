export interface TemplateConfig {
    layout: {
        variant: string
        dir: string,
        sidebar: {
            collapsed: boolean,
            size: string,
            backgroundColor: string,
            backgroundImage: boolean,
            backgroundImageURL: string
        }
    };
}
