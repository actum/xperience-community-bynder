import React, { ChangeEventHandler, useState } from 'react';
import { FormItemWrapper, Button, SidePanel, SidePanelCloseEvent, SidePanelSize, Box, Grid, ContentItemTilePreview, Spacing, IconSize } from '@kentico/xperience-admin-components';
import { CompactView, Login, assetType } from '@bynder/compact-view';
import { Asset } from './Asset';
import { BynderSelectorClientProps } from './BynderSelectorClientProps';

export const BynderSelectorFormComponent = (props: BynderSelectorClientProps) => {
    const initAssets = props.value ?? [];
    
    const [isOpen, setIsOpen] = React.useState<boolean>(false);
    const [selectedAssets, setAssets] = React.useState<Asset[]>(initAssets);
    const [selectedBynderAssets, setBynderAssets] = React.useState<string[]>(initAssets.map((i: { databaseId: any; }) => i.databaseId));

    const bynderAllowedTypes: assetType[] = props.allowedType ? [props.allowedType] : [];

    const selectAssets = (assets: Asset[]) => {
        setAssets(assets);
        setBynderAssets(assets.map(x => x.databaseId));

        const sVal = JSON.stringify(assets);

        if (props.onChange) {
            props.onChange(assets);
        }
    }

    const onSuccess = (assets: unknown[], opts: any) => {
        setIsOpen(false);
        selectAssets(assets.map(i => i as Asset));
    };

    const onRemoveItem = (key:any) => {
        var assets = selectedAssets.filter((item) => { return item.id !==key });
        selectAssets(assets);
    }

    const onViewClose = (value: any) => {
        if (value.source !== 'parent_panel_closed') {
            setIsOpen(false);
        }
    }

    return (               
        <FormItemWrapper
            label={props.label}
            explanationText={props.explanationText}
            invalid={props.invalid}
            validationMessage={props.validationMessage}
            markAsRequired={props.required}
            labelIcon={props.tooltip ? 'xp-i-circle' : undefined}
            labelIconTooltip={props.tooltip}>

            <Box>
                <Box>
                    <Button label='Select file' onClick={() => setIsOpen(true)} />
                </Box>

                <Box>
                    <Grid cols={3} columnGap={Spacing.M}>

                    {selectedAssets?.map((asset: Asset, index: number) => {
                    return (
                        <Box>
                            <ContentItemTilePreview 
                                actions={[
                                    {
                                        title:'Remove',
                                        icon: 'xp-modal-close',
                                        onClick: () => onRemoveItem(asset.id)
                                    }
                                ]}
                                key={asset.id}
                                name={asset.name}
                                contentType='Image'  
                                previewIcon='xp-picture'
                                disabled={false}                                
                                url={asset.files.thumbnail?.url}
                            />
                        </Box>
                    )
                    })}
                    </Grid>
                </Box>            
            </Box> 

            <SidePanel isVisible={isOpen} headline='Bynder' onClose={onViewClose} isMaximizable={true} size={SidePanelSize.Full}  >
                <Login>
                    <CompactView
                        language="en_US"
                        onSuccess={onSuccess}
                        selectedAssets={selectedBynderAssets}
                        mode={props.maximumAssets > 1 ? 'MultiSelect' : 'SingleSelect'}
                        assetTypes={bynderAllowedTypes}
                    />
                </Login>                              
            </SidePanel>                           

        </FormItemWrapper>
    );
};
