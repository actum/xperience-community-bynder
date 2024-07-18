import { File, assetType } from '@bynder/compact-view';

export interface AssetFiles {
    readonly thumbnail: File;
    readonly original: File;
    readonly mini: File;
    readonly webImage: File;
}

export interface Asset {
    readonly id: string;
    readonly name: string;
    readonly description: string;    
    readonly url: string;
    readonly extensions: string[];
    readonly tags: string[];
    readonly databaseId: string;
    readonly type: assetType;
    readonly files: AssetFiles;
}