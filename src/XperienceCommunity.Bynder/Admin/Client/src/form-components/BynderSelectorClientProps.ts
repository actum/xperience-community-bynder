import { FormComponentProps } from '@kentico/xperience-admin-base';
import { assetType } from '@bynder/compact-view';

export interface BynderSelectorClientProps extends FormComponentProps {
    readonly minimumAssets: number;
    readonly maximumAssets: number;
    readonly allowedType: assetType;
}