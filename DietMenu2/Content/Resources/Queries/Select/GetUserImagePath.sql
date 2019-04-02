select r.resource_path
from resource_link_entity rle,
	 resources r
where rle.entity_id = @entityid
  and r.resource_id = rle.resource_id
  and r.resource_type_id = 2
 