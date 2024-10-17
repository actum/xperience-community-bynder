import { File, assetType } from "@bynder/compact-view";

export interface Asset {
  readonly id: string;
  readonly name: string;
  readonly description: string;
  readonly url: string;
  readonly extensions: string[];
  readonly tags: string[];
  readonly databaseId: string;
  readonly type: assetType;
  readonly files: Record<string, File>;
}
