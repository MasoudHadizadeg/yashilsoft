/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.276
 * Time: 2/28/2020 12:16:29 AM
 ************************************************************/

ALTER TABLE base.CommonBaseData
ADD  IsSystemProp	BIT	

UPDATE base.CommonBaseData
SET    IsSystemProp = 0
