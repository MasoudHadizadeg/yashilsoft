export enum NewsType {
    Simple = 1069,
    Gallery = 1075,
    Movie = 1072,
    Notification = 1074,
    Pictorial = 1071
}

export function IsEqual(newsTypeNumber: number, newsType: NewsType) {
    return NewsType[newsTypeNumber] === NewsType[newsType];
}
